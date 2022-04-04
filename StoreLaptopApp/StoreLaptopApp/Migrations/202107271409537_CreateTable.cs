namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            CreateIndex("dbo.Carts", "product_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Carts", new[] { "product_Id" });
            CreateIndex("dbo.Carts", "Product_Id");
        }
    }
}
