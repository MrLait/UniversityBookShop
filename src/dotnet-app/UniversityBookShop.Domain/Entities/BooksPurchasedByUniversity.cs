namespace UniversityBookShop.Domain.Entities;

public class BooksPurchasedByUniversity
{
    public int? Id { get; set; }
    public int? UniversityId { get; set; }
    public int? BookId { get; set; }

    //One to One
    public University? University { get; set; }
    public Book? Book { get; set; }

    //One to Many
    public IList<BooksAvailableForFaculty>? BooksAvailableForFaculty { get; set; }

}
