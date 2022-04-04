namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UploadDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Producers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductTypes", "ProductId", "dbo.Products");
            DropIndex("dbo.Producers", new[] { "ProductId" });
            DropIndex("dbo.ProductTypes", new[] { "ProductId" });
            AddColumn("dbo.Products", "IdProductType", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "IdProducer", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "IdProductType");
            CreateIndex("dbo.Products", "IdProducer");
            AddForeignKey("dbo.Products", "IdProducer", "dbo.Producers", "IdProducer", cascadeDelete: true);
            AddForeignKey("dbo.Products", "IdProductType", "dbo.ProductTypes", "IdProductType", cascadeDelete: true);
            DropColumn("dbo.Producers", "ProductId");
            DropColumn("dbo.ProductTypes", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductTypes", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Producers", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "IdProductType", "dbo.ProductTypes");
            DropForeignKey("dbo.Products", "IdProducer", "dbo.Producers");
            DropIndex("dbo.Products", new[] { "IdProducer" });
            DropIndex("dbo.Products", new[] { "IdProductType" });
            DropColumn("dbo.Products", "IdProducer");
            DropColumn("dbo.Products", "IdProductType");
            CreateIndex("dbo.ProductTypes", "ProductId");
            CreateIndex("dbo.Producers", "ProductId");
            AddForeignKey("dbo.ProductTypes", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Producers", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
