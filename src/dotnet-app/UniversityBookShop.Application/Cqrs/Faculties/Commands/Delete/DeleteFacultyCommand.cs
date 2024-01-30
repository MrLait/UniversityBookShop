using MediatR;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Update;

public class DeleteFacultyCommand : IRequest<ServiceResult<Unit>>
{
    public int Id { get; set; }
}

public class DeleteFacultyCommandHandler :
    IRequestHandler<DeleteFacultyCommand, ServiceResult<Unit>>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteFacultyCommandHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<ServiceResult<Unit>> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Faculties
            .FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(Faculty), request.Id);

        _dbContext.Faculties.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(Unit.Value);
    }
}