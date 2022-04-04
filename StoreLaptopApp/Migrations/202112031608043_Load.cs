namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Load : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "Note");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Note", c => c.Int(nullable: false));
        }
    }
}
