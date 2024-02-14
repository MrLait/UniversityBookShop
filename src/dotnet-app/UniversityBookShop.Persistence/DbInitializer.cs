using Microsoft.EntityFrameworkCore;

namespace UniversityBookShop.Persistence;

public class DbInitializer
{
    public static void Initializer(ApplicationDbContext context)
    {
        context.Database.Migrate();
    }
}
