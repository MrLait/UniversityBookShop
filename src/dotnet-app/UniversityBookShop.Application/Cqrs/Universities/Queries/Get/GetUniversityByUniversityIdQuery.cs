using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Universities.Queries.Get;


public class GetUniversityByUniversityIdQuery : IRequest<ServiceResult<UniversityDto>>
{
    public int UniversityId { get; set; }
}

public class GetUniversityByUniversityIdQueryHandler : IRequestHandler<GetUniversityByUniversityIdQuery, ServiceResult<UniversityDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetUniversityByUniversityIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<UniversityDto>> Handle(GetUniversityByUniversityIdQuery request, CancellationToken cancellationToken)
    {

        var university = await _dbContext.Universities
                        .Where(u => u.Id == request.UniversityId)
                        .Include(x => x.CurrencyCode)
                        .Include(x => x.Faculties)
                        .FirstOrDefaultAsync(cancellationToken: cancellationToken)
            ?? throw new NotFoundException(nameof(University), request.UniversityId);

        var query = _mapper.Map<UniversityDto>(university);
        await UpdateFacultyAndBookCounts(query, cancellationToken);
        return ServiceResult.Success(query); 
    }

    private async Task UpdateFacultyAndBookCounts(UniversityDto university, CancellationToken cancellationToken)
    {
        university.FacultyCount = university.Faculties?.Count ?? 0;
        university.BookCount = await _dbContext.PurchasedBookFaculties
            .Where(x => x.Faculty!.UniversityId == university.Id)
            .CountAsync(cancellationToken);
    }
}