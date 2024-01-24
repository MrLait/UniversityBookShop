using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Persistence.InitialData
{
    internal static class CurrencyCodesInitialData
    {
        public static List<CurrencyCode> GetInitialData()
        {
            return new List<CurrencyCode>() 
            {  
                new(){ Id = 1, Code = "$"}, 
                new(){ Id = 2, Code = "€"},
            };
        }
    }
}
