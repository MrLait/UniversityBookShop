namespace UniversityBookShop.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string? Isbn { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    // price decimal(10,2) 
    public decimal? Price { get; set; }
    public CurrencyCode? CurrencyCode { get; set; }
}
