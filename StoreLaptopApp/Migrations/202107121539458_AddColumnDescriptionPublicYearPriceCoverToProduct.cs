namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnDescriptionPublicYearPriceCoverToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Products", "PublicYear", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Price", c => c.String());
            AddColumn("dbo.Products", "Cover", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Cover");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "PublicYear");
            DropColumn("dbo.Products", "Description");
        }
    }
}
