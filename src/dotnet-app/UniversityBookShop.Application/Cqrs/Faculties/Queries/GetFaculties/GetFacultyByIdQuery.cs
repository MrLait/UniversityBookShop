using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties
{
    public class GetFacultyByIdQuery: IRequest<ServiceResult<FacultyDto>>
    {
        public int FacultyId { get; set; }

        public GetFacultyByIdQuery(int facultyId)
        {
            FacultyId = facultyId;
        }
    }

    public class GetFacultyByIdQueryyHandler :
        IRequestHandler<GetFacultyByIdQuery, ServiceResult<FacultyDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetFacultyByIdQueryyHandler(IApplicationDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ServiceResult<FacultyDto>> Handle(GetFacultyByIdQuery request, CancellationToken cancellationToken)
        {
            var faculty = await _dbContext.Faculties
                .FirstOrDefaultAsync(x => x.Id == request.FacultyId, cancellationToken: cancellationToken);
            var query = _mapper.Map<FacultyDto>(faculty);
            return query != null ? ServiceResult.Success(query) : ServiceResult.Failed<FacultyDto>(ServiceError.NotFound);
        }
    }
}

