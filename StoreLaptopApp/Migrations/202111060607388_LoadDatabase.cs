namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoadDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "product_Id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "product_Id" });
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ProductId = c.Long(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateIndex("dbo.Carts", "product_Id");
            AddForeignKey("dbo.Carts", "product_Id", "dbo.Products", "Id");
        }
    }
}
