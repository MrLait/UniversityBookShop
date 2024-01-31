using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.ServicesModels;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Delete;

public class DeleteBooksAvailableForFacultyCommand : IRequest<ServiceResult<Unit>>
{
    public int Id { get; set; }
}

public class DeleteBooksAvailableForFacultyCommandHandler : 
    IRequestHandler<DeleteBooksAvailableForFacultyCommand, ServiceResult<Unit>>
{
    private readonly IApplicationDbContext _dbContext;
    public DeleteBooksAvailableForFacultyCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<ServiceResult<Unit>> Handle(DeleteBooksAvailableForFacultyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.BooksAvailableForFaculties
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);

        if (entity == 0)
            throw new NotFoundException(nameof(BooksAvailableForFaculties), request.Id);

        return ServiceResult.Success(Unit.Value);
    }
}
