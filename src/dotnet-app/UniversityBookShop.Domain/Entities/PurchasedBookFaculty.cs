namespace UniversityBookShop.Domain.Entities;

public class PurchasedBookFaculty
{
    public int Id { get; set; }
    public int? BookPurchasedBookFacultyId { get; set; }
    public int? FacultyPurchasedBookFacultyId { get; set; }

    //One to One
    public Book? Book { get; set; }
    public Faculty? Faculty { get; set; }
}
