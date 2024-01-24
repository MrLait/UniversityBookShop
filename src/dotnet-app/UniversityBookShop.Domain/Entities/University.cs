namespace UniversityBookShop.Domain.Entities;

public class University
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IList<Faculty>? Faculties { get; set; }
    public decimal? TotalBookPrice { get; set; }

    public int? CurrencyCodesId { get; set; }
    public CurrencyCode? CurrencyCode { get; set; }

    //One to One
    public BooksPurchasedByUniversity? BooksPurchasedByUniversity { get; set; }

}
