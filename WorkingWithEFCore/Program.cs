using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels; // To use Northwind
using NorthwindDb db = new NorthwindDb();

WriteLine($"Provider: {db.Database.ProviderName}");

var categories = await db.Categories
    .AsNoTracking()
    .ToListAsync();

foreach(var c in categories)
{
    Console.WriteLine($"{c.CategoryId} - {c.CategoryName}");
}