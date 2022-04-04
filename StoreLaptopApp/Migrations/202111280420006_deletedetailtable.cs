namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedetailtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "Product_Id", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "Product_Id" });
            DropTable("dbo.OrderDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderId = c.String(nullable: false, maxLength: 128),
                        ProductId = c.String(nullable: false, maxLength: 128),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Order_OrderId = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId });
            
            CreateIndex("dbo.OrderDetails", "Product_Id");
            CreateIndex("dbo.OrderDetails", "Order_OrderId");
            AddForeignKey("dbo.OrderDetails", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
