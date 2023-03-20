namespace UniversityBookShop.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string? Isbn { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public decimal? Price { get; set; }
    public int CurrencyCodesBooksId { get; set; }
    public CurrencyCode? CurrencyCode { get; set; }

    //One to One
    public BooksAvailableForFaculty? BooksAvailableForFaculty { get; set; }
    public PurchasedBookFaculty? PurchasedBookFaculty { get; set; }
    public BooksPurchasedByUniversity? BooksPurchasedByUniversity { get; set; }
}
