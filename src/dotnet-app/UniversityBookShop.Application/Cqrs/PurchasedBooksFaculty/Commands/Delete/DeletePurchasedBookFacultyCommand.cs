using MediatR;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Delete;

public class DeletePurchasedBookFacultyCommand : IRequest
{
    public int Id { get; set; }
}

public class DeletePurchasedBookFacultyCommandHandler : IRequestHandler<DeletePurchasedBookFacultyCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeletePurchasedBookFacultyCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(DeletePurchasedBookFacultyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.PurchasedBookFaculties.FindAsync(new object[] { request.Id });

        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(PurchasedBooksFaculty), request.Id);
        }

        _dbContext.PurchasedBookFaculties.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}


