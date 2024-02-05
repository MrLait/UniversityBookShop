using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;
using UniversityBookShop.Application.Dto.Vm;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Universities.Queries.Get;


public class GetUniversityByUniversityIdWithPaginatedFacultiesQuery : PaginationParams, IRequest<ServiceResult<UniversityWithPaginatedFacultiesVm>>
{
    public int UniversityId { get; set; }
    public GetUniversityByUniversityIdWithPaginatedFacultiesQuery(int universityId, PaginationParams paginationParams)
    {
        UniversityId = universityId;
        SetPaginationParams(paginationParams);
    }
}

public class GetUniversityByUniversityIdWithPaginatedFacultiesQueryHandler : IRequestHandler<GetUniversityByUniversityIdWithPaginatedFacultiesQuery, ServiceResult<UniversityWithPaginatedFacultiesVm>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetUniversityByUniversityIdWithPaginatedFacultiesQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<UniversityWithPaginatedFacultiesVm>> Handle(GetUniversityByUniversityIdWithPaginatedFacultiesQuery request, CancellationToken cancellationToken)
    {
        var faculties = await _dbContext.Faculties
            .AsNoTracking()
            .Where(f => f.UniversityId == request.UniversityId)
            .ProjectTo<FacultyDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken)
            ;

        var university = await _dbContext.Universities
            .AsNoTracking()
            .Where(u => u.Id == request.UniversityId)
            .Select(u => new UniversityWithPaginatedFacultiesVm 
            {
                Id = u.Id,
                Name = u.Name,
                Description = u.Description,
                TotalBookPrice = u.TotalBookPrice,
                CurrencyCode = _mapper.Map<CurrencyCodeDto>(u.CurrencyCode),
                FacultiesWithPagination = faculties,
            })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken)
            ?? throw new NotFoundException(nameof(University), request.UniversityId);


        await UpdateFacultyAndBookCounts(university, cancellationToken);
        return ServiceResult.Success(university); 
    }

    private async Task UpdateFacultyAndBookCounts(UniversityWithPaginatedFacultiesVm university, CancellationToken cancellationToken)
    {
        university.FacultyCount = university?.FacultiesWithPagination?.Items?.Count ?? 0;
        university.BookCount = await _dbContext.PurchasedBookFaculties
            .Where(x => x.Faculty!.UniversityId == university.Id)
            .CountAsync(cancellationToken);
    }
}