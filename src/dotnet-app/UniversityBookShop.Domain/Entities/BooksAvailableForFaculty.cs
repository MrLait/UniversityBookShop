namespace UniversityBookShop.Domain.Entities;

public class BooksAvailableForFaculty
{
    public int Id { get; set; }
    public bool? IsPurchased { get; set; }

    // One to Many
    public int? BookId { get; set; }
    public Book? Book { get; set; }

    public int? FacultyId { get; set; }
    public Faculty? Faculty { get; set; }

    public int? UniversityId { get; set; }
    public University? University { get; set; }
}
