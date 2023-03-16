using AutoMapper;
using MediatR;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Create;

public class CreatePurchasedBooksFacultyCommand : IRequest<int>, IMapWith<PurchasedBookFaculty>
{
    public int Id { get; set; }
    public int? BookId { get; set; }
    public int? FacultyId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePurchasedBooksFacultyCommand, PurchasedBookFaculty>()
        .ForMember(c => c.BookPurchasedBookFacultyId, opt => opt.MapFrom(src => src.BookId))
        .ForMember(c => c.FacultyPurchasedBookFacultyId, opt => opt.MapFrom(src => src.FacultyId));
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
        var purchasedBookFaculty = _mapper.Map<PurchasedBookFaculty>(request);

        await _dbContext.PurchasedBookFaculties.AddAsync(purchasedBookFaculty, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return purchasedBookFaculty.Id;
    }
}