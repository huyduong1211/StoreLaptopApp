namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shows", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Reservations", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "ShowId", "dbo.Shows");
            DropForeignKey("dbo.Shows", "StoreId", "dbo.Stores");
            DropIndex("dbo.Shows", new[] { "StoreId" });
            DropIndex("dbo.Shows", new[] { "ProductId" });
            DropIndex("dbo.Reservations", new[] { "CustomerId" });
            DropIndex("dbo.Reservations", new[] { "ShowId" });
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        BirthDate = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        OrderDate = c.Int(nullable: false),
                        EmployeesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
                .ForeignKey("dbo.Employees", t => t.EmployeesId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeesId);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        IdProducer = c.Int(nullable: false, identity: true),
                        NameProducer = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProducer)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        IdProductType = c.Int(nullable: false, identity: true),
                        NameType = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProductType)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Products", "OrderDetail_Id", c => c.Int());
            CreateIndex("dbo.Products", "OrderDetail_Id");
            AddForeignKey("dbo.Products", "OrderDetail_Id", "dbo.OrderDetails", "Id");
            DropTable("dbo.Shows");
            DropTable("dbo.Reservations");
            DropTable("dbo.Stores");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        ShowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.ProductTypes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Producers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "OrderDetail_Id", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "EmployeesId", "dbo.Employees");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.AspNetUsers");
            DropIndex("dbo.ProductTypes", new[] { "ProductId" });
            DropIndex("dbo.Producers", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "EmployeesId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Products", new[] { "OrderDetail_Id" });
            DropColumn("dbo.Products", "OrderDetail_Id");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Producers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Employees");
            CreateIndex("dbo.Reservations", "ShowId");
            CreateIndex("dbo.Reservations", "CustomerId");
            CreateIndex("dbo.Shows", "ProductId");
            CreateIndex("dbo.Shows", "StoreId");
            AddForeignKey("dbo.Shows", "StoreId", "dbo.Stores", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "ShowId", "dbo.Shows", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "CustomerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Shows", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
