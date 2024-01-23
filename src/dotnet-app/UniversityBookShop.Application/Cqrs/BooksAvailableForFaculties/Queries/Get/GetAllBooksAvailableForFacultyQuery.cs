using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get;

public class GetAllBooksAvailableForFacultyQuery : IRequest<PaginatedList<BooksAvailableForFacultyDto>>
{
    public PaginationParams? PaginationParams { get; set; }
}

public class GetAllBooksQueryHandler :
    IRequestHandler<GetAllBooksAvailableForFacultyQuery, PaginatedList<BooksAvailableForFacultyDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllBooksQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<PaginatedList<BooksAvailableForFacultyDto>> Handle(GetAllBooksAvailableForFacultyQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.BooksAvailableForFaculties
                            .ProjectTo<BooksAvailableForFacultyDto>(_mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PaginationParams.PageIndex, request.PaginationParams.PageSize, cancellationToken);

        return query.Items.Any() ? query : throw new Exception("Not found"); // ToDo. I have to add failed message
    }
}
