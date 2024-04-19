namespace UniversityBookShop.Application.Common.Models.AbstractValidators
{
    public class BookCommandBase
    {
        public string Isbn { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal? Price { get; set; }
        public int CurrencyCodeId { get; set; }
    }
}