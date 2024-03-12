using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Persistence.InitialData
{
    internal static class UniversityInitialData
    {
        public static List<University> GetInitialData()
        {
            return new List<University>()
            {
                new University() { Id = 1, Name = "Starlight University", Description = "A leading institution dedicated to excellence in education and research.", CurrencyCodesId = 1 },
                new University() { Id = 2, Name = "Galactic Institute of Technology", Description = "Empowering the future through cutting-edge technology and innovation.", CurrencyCodesId = 1 },
                new University() { Id = 3, Name = "Celestial Arts Academy", Description = "Nurturing creativity and talent in the fields of arts and humanities.", CurrencyCodesId = 1 },
                new University() { Id = 4, Name = "Stellar Business School", Description = "Shaping visionary leaders for the global business landscape.", CurrencyCodesId = 1 },
                new University() { Id = 5, Name = "Lunar Medical University", Description = "Advancing healthcare through research, education, and compassionate practice.", CurrencyCodesId = 1 },
                new University() { Id = 6, Name = "Astrological Sciences Institute", Description = "Exploring the mysteries of the cosmos through scientific inquiry.", CurrencyCodesId = 1 },
                new University() { Id = 7, Name = "Nova Environmental Studies Center", Description = "Fostering environmental stewardship and sustainability for a brighter future.", CurrencyCodesId = 1 },
                new University() { Id = 8, Name = "Cosmic Engineering Academy", Description = "Training the next generation of engineers to build a better universe.", CurrencyCodesId = 1 },
                new University() { Id = 9, Name = "Eclipse Law School", Description = "Dedicated to legal excellence and justice in the interstellar community.", CurrencyCodesId = 1 },
                new University() { Id = 10, Name = "Astronomy and Astrophysics College", Description = "Unraveling the mysteries of the cosmos through rigorous scientific study.", CurrencyCodesId = 1 },
                new University() { Id = 11, Name = "Interplanetary Social Sciences Institute", Description = "Understanding society and its dynamics on a global scale for a harmonious future.", CurrencyCodesId = 1 },
                new University() { Id = 12, Name = "Quantum Computing Research Center", Description = "Pushing the boundaries of computing to unlock new frontiers in technology.", CurrencyCodesId = 1 },

            };
        }
    }
}
