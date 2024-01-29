using AutoMapper;
using MediatR;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Create;

public class AddBooksAvailableForFacultyCommand : IRequest<int>, IMapWith<BooksAvailableForFaculty>
{
    public int? BookId { get; set; }
    public int? FacultyId { get; set; }
    public int? UniversityId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AddBooksAvailableForFacultyCommand, BooksAvailableForFaculty>()
        .ForMember(c => c.BooksPurchasedByUniversityId, opt => opt.MapFrom(src => src.UniversityId));
    }
}

public class AddBooksAvailableForFacultyCommandHandler : IRequestHandler<AddBooksAvailableForFacultyCommand, int>
{
    private protected IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public AddBooksAvailableForFacultyCommandHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    public async Task<int> Handle(AddBooksAvailableForFacultyCommand request, CancellationToken cancellationToken)
    {
        var purchasedBook = _mapper.Map<BooksAvailableForFaculty>(request);
        purchasedBook.IsPurchased = false;

        await _dbContext.BooksAvailableForFaculties.AddAsync(purchasedBook, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return purchasedBook.Id;
    }
}