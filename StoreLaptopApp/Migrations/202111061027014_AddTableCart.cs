namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        IdCart = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quangtity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Total = c.Int(nullable: false),
                        product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IdCart)
                .ForeignKey("dbo.Products", t => t.product_Id)
                .Index(t => t.product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "product_Id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "product_Id" });
            DropTable("dbo.Carts");
        }
    }
}
