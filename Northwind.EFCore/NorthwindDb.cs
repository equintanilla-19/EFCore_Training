using System.Data.Common;
using Microsoft.EntityFrameworkCore; // To use DbContext and so on

namespace Northwind.EntityModels;

// This manages interactions with the Northwind database
public class NorthwindDb : DbContext
{
    private static string connString = "Data Source=dbc:sqlite:C:\\Users\\emiliano.quintanilla\\source\\EFCore_Training\\Northwind";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string databaseFile = "Northwind.db";
        string path = Path.Combine(Environment.CurrentDirectory, databaseFile);

        WriteLine($"Connection: {connString}");
        
        optionsBuilder.UseSqlite(connString);
    }
}