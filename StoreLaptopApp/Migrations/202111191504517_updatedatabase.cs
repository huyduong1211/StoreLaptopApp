namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
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
                        IdCart = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quangtity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IdCart);
            
            CreateIndex("dbo.Carts", "product_Id");
            AddForeignKey("dbo.Carts", "product_Id", "dbo.Products", "Id");
        }
    }
}
