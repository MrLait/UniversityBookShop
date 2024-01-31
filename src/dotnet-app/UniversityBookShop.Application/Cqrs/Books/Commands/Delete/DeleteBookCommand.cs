using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Books.Commands.Delete;

public class DeleteBookCommand : IRequest<ServiceResult<Unit>>
{
    public int Id { get; set; }
}

public class DeleteBookCommandHandler :
    IRequestHandler<DeleteBookCommand, ServiceResult<Unit>>
{
    private readonly IApplicationDbContext _dbContext;
    public DeleteBookCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<ServiceResult<Unit>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Books
            .Where(x =>x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);

        if (entity == 0)
            throw new NotFoundException(nameof(Book), request.Id);

        return ServiceResult.Success(Unit.Value);
    }
}
