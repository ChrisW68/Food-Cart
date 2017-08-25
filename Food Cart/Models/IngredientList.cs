using System.Collections.Generic;

namespace Food_Cart.Models
{
    public enum Category
    {
        Bread, Condiment, Dairy, Produce, Protein
    }

    public class IngredientList
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public Category? Category { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
        
    }
}

