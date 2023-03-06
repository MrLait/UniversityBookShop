using MediatR;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Universities.Commands.Create;

public class CreateUniversityCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int CurrencyCodeId { get; set; }
}

public class CreateUniversityCommandHandler :
    IRequestHandler<CreateUniversityCommand, int>
{
    private readonly IApplicationDbContext _dbContext;
    public CreateUniversityCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<int> Handle(CreateUniversityCommand request, CancellationToken cancellationToken)
    {
        var university = new University
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            CurrencyCodesUniversitiesId = request.CurrencyCodeId
        };

        await _dbContext.Universities.AddAsync(university, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return university.Id;
    }
}