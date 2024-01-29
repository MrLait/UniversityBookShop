namespace UniversityBookShop.Domain.Entities;

public class Faculty
{
    public int Id { get; set; }
    public string? Name { get; set; }

    //One to Many
    public int? UniversityId { get; set; }
    public University? University { get; set; }

    public List<PurchasedBookFaculty>? PurchasedBookFaculty { get; set; }
    public List<BooksAvailableForFaculty>? BooksAvailableForFaculty { get; set; }
}
