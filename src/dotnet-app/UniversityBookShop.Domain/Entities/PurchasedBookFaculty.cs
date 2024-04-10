namespace UniversityBookShop.Domain.Entities;

public class PurchasedBookFaculty
{
    public int Id { get; set; }

    //One to Many
    public int? BookId { get; set; }
    public Book Book { get; set; }

    public int? FacultyId { get; set; }
    public Faculty Faculty { get; set; }
}
