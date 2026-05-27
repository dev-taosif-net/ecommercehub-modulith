using Shared.Persistence.Seed;

namespace Catalog.Persistence.Seed;

public class CatalogDataSeeder(CatalogDbContext dbContext) : IDataSeeder
{
    public async Task SeedAsync()
    {
        if (!await dbContext.Products.AnyAsync())
        {
            await dbContext.Products.AddRangeAsync(InitialData.Products);
            await dbContext.SaveChangesAsync();
        }
    }
}

