namespace Food_Cart.Migrations
{
    using Food_Cart.Models;
    using Food_Cart.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InventoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var Ingredients = new List<IngredientList>
              { new IngredientList { Name = "Cheese", Quantity = 20, Cost= 2.50m, Category = Category.Dairy},
                new IngredientList {Name = "Ham", Quantity = 15, Cost= 4.00M, Category = Category.Protein },
                new IngredientList {Name = "Lettuce", Quantity = 12, Cost = 2.00M, Category = Category.Produce },
                new IngredientList {Name = "Wheat", Quantity = 24, Cost = 3.50M, Category = Category.Bread }
              };
            Ingredients.ForEach(s => context.IngredientLists.AddorUpdate(p => p.ID));
            context.SaveChanges();
        }
    }
}
