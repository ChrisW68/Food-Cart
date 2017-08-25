
using Food_Cart.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Food_Cart.DAL
{
    public class InventoryContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<IngredientList> IngredientLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove <PluralizingTableNameConvention>();
            modelBuilder.Entity<MenuItem>()
                .HasMany(i => i.IngredientLists).WithMany(m => m.MenuItems)
                .Map(t => t.MapLeftKey("MenuItemID")
                    .MapRightKey("IngredientListID")
                    .ToTable("MenutoIngredients")
                    );
        }
    }
}