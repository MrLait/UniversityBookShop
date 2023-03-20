namespace UniversityBookShop.Domain.Entities;

public class BooksAvailableForFaculty
{
    public int? Id { get; set; }
    public int? BookId { get; set; }
    public int? FacultyId { get; set; }
    public bool? IsPurchased { get; set; }
    public int? BooksPurchasedByUniversityId { get; set; }

    // One to One
    public Book? Book { get; set; }
    public Faculty? Faculty { get; set; }

    // One to Many
    public BooksPurchasedByUniversity? BooksPurchasedByUniversity { get; set; }
}
