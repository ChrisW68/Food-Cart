namespace Food_Cart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IngredientList",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.Int(),
                        MenuItem_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuItem", t => t.MenuItem_ID)
                .Index(t => t.MenuItem_ID);
            
            CreateTable(
                "dbo.MenuItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IngredientList", "MenuItem_ID", "dbo.MenuItem");
            DropIndex("dbo.IngredientList", new[] { "MenuItem_ID" });
            DropTable("dbo.MenuItem");
            DropTable("dbo.IngredientList");
        }
    }
}
