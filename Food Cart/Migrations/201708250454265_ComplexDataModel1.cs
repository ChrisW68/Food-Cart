namespace Food_Cart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IngredientList", "MenuItem_ID", "dbo.MenuItem");
            DropIndex("dbo.IngredientList", new[] { "MenuItem_ID" });
            CreateTable(
                "dbo.MenutoIngredients",
                c => new
                    {
                        MenuItemID = c.Int(nullable: false),
                        IngredientListID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuItemID, t.IngredientListID })
                .ForeignKey("dbo.MenuItem", t => t.MenuItemID, cascadeDelete: true)
                .ForeignKey("dbo.IngredientList", t => t.IngredientListID, cascadeDelete: true)
                .Index(t => t.MenuItemID)
                .Index(t => t.IngredientListID);
            
            DropColumn("dbo.IngredientList", "MenuItem_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IngredientList", "MenuItem_ID", c => c.Int());
            DropForeignKey("dbo.MenutoIngredients", "IngredientListID", "dbo.IngredientList");
            DropForeignKey("dbo.MenutoIngredients", "MenuItemID", "dbo.MenuItem");
            DropIndex("dbo.MenutoIngredients", new[] { "IngredientListID" });
            DropIndex("dbo.MenutoIngredients", new[] { "MenuItemID" });
            DropTable("dbo.MenutoIngredients");
            CreateIndex("dbo.IngredientList", "MenuItem_ID");
            AddForeignKey("dbo.IngredientList", "MenuItem_ID", "dbo.MenuItem", "ID");
        }
    }
}
