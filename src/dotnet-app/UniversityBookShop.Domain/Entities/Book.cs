namespace UniversityBookShop.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string? Isbn { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public decimal? Price { get; set; }

    public int? CurrencyCodesId { get; set; }
    public CurrencyCode? CurrencyCode { get; set; }

    //One to Many
    public List<PurchasedBookFaculty>? PurchasedBookFaculty { get; set; }
    public List<BooksAvailableForFaculty>? BooksAvailableForFaculty { get; set; }
    //public List<BooksPurchasedByUniversity>? BooksPurchasedByUniversity { get; set; }
}
