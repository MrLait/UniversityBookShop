using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Persistence.InitialData
{
    internal static class BookInitialData
    {
        public static List<Book> GetInitialData()
        {
            return new List<Book>()
            {
                new Book() { Id = 1, Isbn = "123456789012", Name = "The Hidden Galaxy", Author = "Alice Starlight", Price = 10, CurrencyCodesId = 1 },
                new Book() { Id = 2, Isbn = "234567890123", Name = "Echoes of Eternity", Author = "David Nebula", Price = 15, CurrencyCodesId = 1 },
                new Book() { Id = 3, Isbn = "345678901234", Name = "Serenade of Shadows", Author = "Mia Moonshade", Price = 20, CurrencyCodesId = 1 },
                new Book() { Id = 4, Isbn = "456789012345", Name = "Whispers in the Wind", Author = "Elijah Stardust", Price = 25, CurrencyCodesId = 1 },
                new Book() { Id = 5, Isbn = "567890123456", Name = "The Enchanted Chronicles", Author = "Isabella Dreamweaver", Price = 30, CurrencyCodesId = 1 },
                new Book() { Id = 6, Isbn = "678901234567", Name = "Chronicles of Arcadia", Author = "Oliver Starcrafter", Price = 35, CurrencyCodesId = 1 },
                new Book() { Id = 7, Isbn = "789012345678", Name = "Legends of Lumina", Author = "Sophia Silverleaf", Price = 40, CurrencyCodesId = 1 },
                new Book() { Id = 8, Isbn = "890123456789", Name = "Eternal Echoes", Author = "Gabriel Nightshade", Price = 45, CurrencyCodesId = 1 },
                new Book() { Id = 9, Isbn = "901234567890", Name = "Starlight Sonata", Author = "Aria Stardancer", Price = 50, CurrencyCodesId = 1 },
                new Book() { Id = 10, Isbn = "012345678901", Name = "Moonlit Whispers", Author = "Liam Shadowcaster", Price = 55, CurrencyCodesId = 1 },
                new Book() { Id = 11, Isbn = "112233445566", Name = "Wonders of Whimsy", Author = "Serena Dreamweaver", Price = 60, CurrencyCodesId = 1 },
                new Book() { Id = 12, Isbn = "223344556677", Name = "Stardust Serenade", Author = "Lucas Starborn", Price = 65, CurrencyCodesId = 1 },
                new Book() { Id = 13, Isbn = "334455667788", Name = "Realm of Radiance", Author = "Aurora Celestia", Price = 70, CurrencyCodesId = 1 },
                new Book() { Id = 14, Isbn = "445566778899", Name = "Midnight Mirage", Author = "Xander Nightshade", Price = 75, CurrencyCodesId = 1 },
                new Book() { Id = 15, Isbn = "556677889900", Name = "Twilight Tales", Author = "Fiona Starlight", Price = 80, CurrencyCodesId = 1 },
                new Book() { Id = 16, Isbn = "667788990011", Name = "Cerulean Chronicles", Author = "Zane Moonshadow", Price = 85, CurrencyCodesId = 1 },
                new Book() { Id = 17, Isbn = "778899001122", Name = "Luminous Legends", Author = "Elena Stardust", Price = 90, CurrencyCodesId = 1 },
                new Book() { Id = 18, Isbn = "889900112233", Name = "Galactic Gala", Author = "Orion Starcrafter", Price = 95, CurrencyCodesId = 1 },
            };
        }
    }
}
