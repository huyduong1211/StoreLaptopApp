namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateinfotabletodb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropPrimaryKey("dbo.OrderDetails");
            AddColumn("dbo.OrderDetails", "Order_OrderId", c => c.Int());
            AddColumn("dbo.OrderDetails", "Product_Id", c => c.Int());
            AddColumn("dbo.Orders", "Confirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "Delivered", c => c.Boolean(nullable: false));
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.OrderDetails", "ProductId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.OrderDetails", new[] { "OrderId", "ProductId" });
            CreateIndex("dbo.OrderDetails", "Order_OrderId");
            CreateIndex("dbo.OrderDetails", "Product_Id");
            AddForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders", "OrderId");
            AddForeignKey("dbo.OrderDetails", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.OrderDetails", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.OrderDetails", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Product_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderId" });
            DropPrimaryKey("dbo.OrderDetails");
            AlterColumn("dbo.OrderDetails", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Delivered");
            DropColumn("dbo.Orders", "Confirmed");
            DropColumn("dbo.OrderDetails", "Product_Id");
            DropColumn("dbo.OrderDetails", "Order_OrderId");
            AddPrimaryKey("dbo.OrderDetails", "Id");
            CreateIndex("dbo.OrderDetails", "ProductId");
            CreateIndex("dbo.OrderDetails", "OrderId");
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
    }
}
