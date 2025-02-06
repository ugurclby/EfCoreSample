using EfCoreSample.DbFirst.DAL;
using Microsoft.EntityFrameworkCore;

DbContextInitializer.Build();

using (var dbContext = new AppDbContext())
{
    var products = await dbContext.Products.ToListAsync();
}