namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTableProducTypeProducerProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Note", c => c.String());
            AddColumn("dbo.Producers", "Status", c => c.String());
            AddColumn("dbo.ProductTypes", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductTypes", "Status");
            DropColumn("dbo.Producers", "Status");
            DropColumn("dbo.Products", "Note");
        }
    }
}
