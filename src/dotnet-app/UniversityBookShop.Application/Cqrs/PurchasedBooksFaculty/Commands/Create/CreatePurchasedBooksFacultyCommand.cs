using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Create;

public class CreatePurchasedBooksFacultyCommand : IRequest<ServiceResult<int>>, IMapWith<PurchasedBookFaculty>
{
    public int? BookId { get; set; }
    public int? FacultyId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePurchasedBooksFacultyCommand, PurchasedBookFaculty>();
    }
}

public class CreatePurchasedBookFacultyCommandHandler : IRequestHandler<CreatePurchasedBooksFacultyCommand, ServiceResult<int>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreatePurchasedBookFacultyCommandHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<int>> Handle(CreatePurchasedBooksFacultyCommand request, CancellationToken cancellationToken)
    {
        var facultyExist = await _dbContext.Faculties
            .SingleOrDefaultAsync(c => c.Id == request.FacultyId, cancellationToken)
            ?? throw new NotFoundException(nameof(Faculty), request.FacultyId!);
        var isBookExist = await _dbContext.Books
            .AnyAsync(c => c.Id == request.BookId, cancellationToken);
        if (!isBookExist) throw new NotFoundException(nameof(Book), request.BookId!);

        var isPurchasedThisFaculty = await _dbContext.PurchasedBookFaculties
                .AnyAsync(p => p.BookId == request.BookId && p.FacultyId == request.FacultyId, cancellationToken);
        if (isPurchasedThisFaculty) return ServiceResult.Failed<int>(ServiceError.BookPurchaseFacultyError);

        var universityId = facultyExist.UniversityId;
        var isPurchasedThisUnivercity = await _dbContext.PurchasedBookFaculties
                .AnyAsync(p => p.BookId == request.BookId && p.Faculty.UniversityId == universityId, cancellationToken);
        if (isPurchasedThisUnivercity) return ServiceResult.Failed<int>(ServiceError.BookPurchaseUniversityError);

        var purchasedBookFaculty = _mapper.Map<PurchasedBookFaculty>(request);

        await _dbContext.PurchasedBookFaculties.AddAsync(purchasedBookFaculty, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(purchasedBookFaculty.Id);
    }
}