namespace UniversityBookShop.Domain.Entities;

public class CurrencyCode
{
    public int Id { get; set; }
    public string? Code { get; set; }

    public int UniversitiesCurrencyCodesId { get; set; }
    public University? University { get; set; }
}
