using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto.Vm;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get;

public class GetPurchasedBooksByFacultyIdWithPaginationQuery : PaginationParams, IRequest<ServiceResult<PaginatedList<PurchasedBookByFacultyIdVm>>>
{
    public int FacultyId { get; set; }

    public GetPurchasedBooksByFacultyIdWithPaginationQuery(PaginationParams paginationParams, int facultyId)
    {
        SetPaginationParams(paginationParams);
        FacultyId = facultyId;
    }
}

public class GetPurchasedBooksByFacultyIdQueryHandler : IRequestHandler<GetPurchasedBooksByFacultyIdWithPaginationQuery, ServiceResult<PaginatedList<PurchasedBookByFacultyIdVm>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetPurchasedBooksByFacultyIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<PaginatedList<PurchasedBookByFacultyIdVm>>> Handle(GetPurchasedBooksByFacultyIdWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var facultyExist = await _dbContext.Faculties
            .AnyAsync(f => f.Id == request.FacultyId, cancellationToken);
        if (!facultyExist) return ServiceResult.Failed<PaginatedList<PurchasedBookByFacultyIdVm>>(ServiceError.NotFound);

        var query = await _dbContext.PurchasedBookFaculties
            .Where(x => x.FacultyId == request.FacultyId)
            .Include(x => x.Book)
                .ThenInclude(x => x.CurrencyCode)
            .Select(x => _mapper.Map<PurchasedBookByFacultyIdVm>(x))
            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

        return query.Items.Any() ? ServiceResult.Success(query) : ServiceResult.Failed(query, ServiceError.NotFound);
    }
}