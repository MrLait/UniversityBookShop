using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Create;

public class AddBooksAvailableForFacultyCommand :
    IRequest<ServiceResult<int>>, IMapWith<BooksAvailableForFaculty>
{
    public int? BookId { get; set; }
    public int? FacultyId { get; set; }
    public int? UniversityId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AddBooksAvailableForFacultyCommand, BooksAvailableForFaculty>()
        .ForMember(c => c.UniversityId, opt => opt.MapFrom(src => src.UniversityId));
    }
}

public class AddBooksAvailableForFacultyCommandHandler : IRequestHandler<AddBooksAvailableForFacultyCommand, ServiceResult<int>>
{
    private protected IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public AddBooksAvailableForFacultyCommandHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<int>> Handle(AddBooksAvailableForFacultyCommand request, CancellationToken cancellationToken)
    {
        var isBookAvailable = await _dbContext.BooksAvailableForFaculties
            .AnyAsync(c => c.BookId == request.BookId, cancellationToken);
        if (!isBookAvailable) throw new NotFoundException(nameof(Book), request.BookId!);

        var facultyExist = await _dbContext.Faculties
            .Include(x => x.University)
            .Include(x => x.PurchasedBookFaculty)
            .SingleOrDefaultAsync(c => c.Id == request.FacultyId, cancellationToken)
            ?? throw new NotFoundException(nameof(Faculty), request.FacultyId!);

        if(facultyExist.UniversityId != request.UniversityId)
            return ServiceResult.Failed<int>(ServiceError.ThereIsNoUniversityForFaculty);

        var isAdded = await _dbContext.BooksAvailableForFaculties
            .AnyAsync(x => x.BookId == request.BookId && x.FacultyId == request.FacultyId, cancellationToken);
        if (isAdded) return ServiceResult.Failed<int>(ServiceError.EntityAlreadyExists);

        var purchasedBook = _mapper.Map<BooksAvailableForFaculty>(request);

        purchasedBook.IsPurchased = facultyExist.PurchasedBookFaculty != null &&
                            facultyExist.PurchasedBookFaculty.Any(x => x.BookId == request.BookId);

        await _dbContext.BooksAvailableForFaculties.AddAsync(purchasedBook, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(purchasedBook.Id);
    }
}