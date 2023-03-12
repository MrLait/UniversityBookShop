namespace UniversityBookShop.Domain.Entities;

public class PurchasedBookFaculty
{
    public int Id { get; set; }
    public Book? Book { get; set; }
    public Faculty? Faculty { get; set; }
}
