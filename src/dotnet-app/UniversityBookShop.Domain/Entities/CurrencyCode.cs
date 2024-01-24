namespace UniversityBookShop.Domain.Entities;

public class CurrencyCode
{
    public int Id { get; set; }
    public string? Code { get; set; }

    //One to one
    public University? University { get; set; }
    public Book? Book { get; set; }
}
