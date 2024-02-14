using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.AbstractValidators;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Create;

public class CreateFacultyCommand : FacultyCommandBase, IRequest<ServiceResult<int>>
{
}

public class CreateFacultiesCommandHandler : IRequestHandler<CreateFacultyCommand, ServiceResult<int>>
{
    private readonly IApplicationDbContext _dbContext;
    public CreateFacultiesCommandHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<ServiceResult<int>> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
    {
        var universityExists = await _dbContext.Universities
            .FirstOrDefaultAsync(c => c.Id == request.UniversityId, cancellationToken)
            ?? throw new NotFoundException(nameof(University), request.UniversityId);

        var faculty = new Faculty
        {
            Name = request.Name,
            UniversityId = request.UniversityId
        };

        await _dbContext.Faculties.AddAsync(faculty, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(faculty.Id);
    }
}