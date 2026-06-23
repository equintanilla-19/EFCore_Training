using System.ComponentModel.DataAnnotations.Schema; // To use [Column]

namespace Northwind.EntityModels;

public class Category
{
    // These prperties map to columns in the database
    public int CategoryId { get; set; } // The primary key
    public string CategoryName { get; set; } = null!;
    public string Description { get; set; } = null!;

    // Defines a navifation property for related rows
    public virtual ICollection<Products> Products { get; set; } = new HashSet<Products>();
    /* 
    * To enable developers to add products to a Category,
    * we must initialize the navigation property to an empty collection.
    * This also avoids an exception if we get a member like Count.
    */


}
