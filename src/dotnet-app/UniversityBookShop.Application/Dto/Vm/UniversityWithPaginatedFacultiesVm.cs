using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Dto.Vm
{
    public class UniversityWithPaginatedFacultiesVm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? TotalBookPrice { get; set; }
        public CurrencyCodeDto? CurrencyCode { get; set; }
        public PaginatedList<FacultyDto>? FacultiesWithPagination { get; set; }
        public int FacultyCount { get; set; }
        public int BookCount { get; set; }
    }
}