namespace BackOffice.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IBookRepository Books { get; set; }
}
