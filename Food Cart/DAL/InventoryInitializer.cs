using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Food_Cart.Models;

namespace Food_Cart.DAL
{
    public class InventoryInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<InventoryContext>
    {
        protected override void Seed(InventoryContext context)
        {
            var MenuItems = new List<MenuItem>
            {
                new MenuItem{Name="Ham and Chees",
                             Price=9.50M},
                new MenuItem{Name="Grilled Cheese",
                             Price=5.25M}
            };

            MenuItems.ForEach(m => context.MenuItems.Add(m));
            context.SaveChanges();
            var IngredientLists = new List<IngredientList>
            {
                new IngredientList { Name = "Cheese", Quantity = 20, Cost= 2.5M, Category = Category.Dairy},
                new IngredientList {Name = "Ham", Quantity = 15, Cost= 4.0M, Category = Category.Protein },
                new IngredientList {Name = "Lettuce", Quantity = 12, Cost = 2.0M, Category = Category.Produce },
                new IngredientList {Name = "Wheat", Quantity = 24, Cost = 3.5M, Category = Category.Bread }
            };
            IngredientLists.ForEach(i => context.IngredientLists.Add(i));
            context.SaveChanges();
        }
    }
}