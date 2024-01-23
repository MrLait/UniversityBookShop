namespace UniversityBookShop.Domain.Entities;

public class Faculty
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? UniversityId { get; set; }

    //One to One
    public PurchasedBookFaculty? PurchasedBookFaculty { get; set; }
    public BooksAvailableForFaculty? BooksAvailableForFaculty { get; set; }

    //One to Many
    public University? University { get; set; }

}
