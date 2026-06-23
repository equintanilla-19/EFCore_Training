using System.Data.Common;
using Microsoft.EntityFrameworkCore; // To use DbContext and so on

namespace Northwind.EntityModels;

// This manages interactions with the Northwind database
public class NorthwindDb : DbContext
{
    // These two properties map to tables in the database
    public DbSet<Category> Categories { get; set; }
    public DbSet<Products> Products { get; set; }

    private static string connectionString = "Data Source=dbc:sqlite:C:\\Users\\emiliano.quintanilla\\source\\EFCore_Training\\Northwind";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string databaseFile = "Northwind.db";
        string path = Path.Combine(Environment.CurrentDirectory, databaseFile);

        WriteLine($"Connection: {connectionString}");
        
        optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Example of using Fluent API instead of attributes to
        // limit the length of a category name to 15
        modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired() // Not null
            .HasMaxLength(15);

        //Some SQLite-specific configuration
        if (Database.ProviderName?.Contains("SQLite") ?? false)
        {
            // To "fix" the lack of decimal support in SQLite
            modelBuilder.Entity<Products>()
                .Property(product => product.Cost)
                .HasConversion<double>();
        }
    }
}