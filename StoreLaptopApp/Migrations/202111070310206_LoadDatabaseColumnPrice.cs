namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoadDatabaseColumnPrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carts", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Carts", "Price", c => c.Double(nullable: false));
        }
    }
}
