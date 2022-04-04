namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoadLoad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Note", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Note");
        }
    }
}
