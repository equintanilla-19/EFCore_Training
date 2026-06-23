using Northwind.EntityModels; // To use Northwind
using NorthwindDb db = new();

WriteLine($"Provider: {db.Database.ProviderName}");
// Disposes the database context.