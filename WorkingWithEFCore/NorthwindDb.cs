using System.Data.Common;
using Microsoft.EntityFrameworkCore; // To use DbContext and so on

namespace Northwind.EntityModels;

// This manages interactions with the Northwind database
public class NorthwindDb : DbContext
{
    // These two properties map to tables in the database
    public DbSet<Category> Categories { get; set; }
    public DbSet<Products> Products { get; set; }

    private static string connectionString = @"C:\Users\emiliano.quintanilla\OneDrive - The MJ Companies\Desktop\Northwind\Northwind.db";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={connectionString}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Example of using Fluent API instead of attributes to
        // limit the length of a category name to 15
        modelBuilder.Entity<Category>()
            .HasKey(c => c.CategoryId);
        
        modelBuilder.Entity<Products>()
            .HasKey(p => p.ProductId);
    }
}