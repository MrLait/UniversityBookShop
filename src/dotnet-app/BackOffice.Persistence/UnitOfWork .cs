using BackOffice.Application.Common.Interfaces;

namespace BackOffice.Persistence;

public class UnitOfWork : IUnitOfWork
{
    public IBookRepository Books { get; set; }

    public UnitOfWork(IBookRepository bookRepository)
    {
        Books = bookRepository;
    }
}
