namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTableProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Cover1", c => c.String());
            AddColumn("dbo.Products", "Cover2", c => c.String());
            AddColumn("dbo.Products", "Cover3", c => c.String());
            AddColumn("dbo.Products", "Cover4", c => c.String());
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Like", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Like");
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Products", "Cover4");
            DropColumn("dbo.Products", "Cover3");
            DropColumn("dbo.Products", "Cover2");
            DropColumn("dbo.Products", "Cover1");
        }
    }
}
