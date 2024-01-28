using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Create;

public class CreatePurchasedBooksFacultyCommand : IRequest<int>, IMapWith<PurchasedBookFaculty>
{
    public int? BookId { get; set; }
    public int? FacultyId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePurchasedBooksFacultyCommand, PurchasedBookFaculty>()
        .ForMember(c => c.FacultyId, opt => opt.MapFrom(src => src.BookId))
        .ForMember(c => c.BookId, opt => opt.MapFrom(src => src.FacultyId));
    }
}

public class CreatePurchasedBookFacultyCommandHandler : IRequestHandler<CreatePurchasedBooksFacultyCommand, int>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreatePurchasedBookFacultyCommandHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<int> Handle(CreatePurchasedBooksFacultyCommand request, CancellationToken cancellationToken)
    {
        var facultyExist = await _dbContext.Faculties
            .FirstOrDefaultAsync(c => c.Id == request.FacultyId, cancellationToken)
            ?? throw new NotFoundException(nameof(Faculty), request.FacultyId!);
        var bookExist = await _dbContext.Books
            .FirstOrDefaultAsync(c => c.Id == request.BookId, cancellationToken)
            ?? throw new NotFoundException(nameof(Book), request.BookId!);

        var purchasedBookFaculty = _mapper.Map<PurchasedBookFaculty>(request);

        await _dbContext.PurchasedBookFaculties.AddAsync(purchasedBookFaculty, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return purchasedBookFaculty.Id;
    }
}