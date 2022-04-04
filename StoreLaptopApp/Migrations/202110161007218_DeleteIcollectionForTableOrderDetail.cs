namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteIcollectionForTableOrderDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "OrderDetail_Id", "dbo.OrderDetails");
            DropIndex("dbo.Products", new[] { "OrderDetail_Id" });
            DropColumn("dbo.Products", "OrderDetail_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "OrderDetail_Id", c => c.Int());
            CreateIndex("dbo.Products", "OrderDetail_Id");
            AddForeignKey("dbo.Products", "OrderDetail_Id", "dbo.OrderDetails", "Id");
        }
    }
}
