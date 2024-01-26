using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Books.Queries.Get;

public class GetAllBooksQuery : IRequest<ServiceResult<PaginatedList<BookDto>>>
{
    public PaginationParams? PaginationParams { get; set; }
}

public class GetAllBooksQueryHandler :
    IRequestHandler<GetAllBooksQuery, ServiceResult<PaginatedList<BookDto>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllBooksQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<PaginatedList<BookDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.Books
                            .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PaginationParams.PageIndex, request.PaginationParams.PageSize, cancellationToken);

        return query.Items.Any() ? ServiceResult.Success(query) : ServiceResult.Failed<PaginatedList<BookDto>>(ServiceError.NotFound);
    }
}