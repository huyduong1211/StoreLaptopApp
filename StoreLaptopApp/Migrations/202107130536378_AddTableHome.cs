namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableHome : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Homes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Cover = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Shows", "HomeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shows", "HomeId");
            AddForeignKey("dbo.Shows", "HomeId", "dbo.Homes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shows", "HomeId", "dbo.Homes");
            DropIndex("dbo.Shows", new[] { "HomeId" });
            DropColumn("dbo.Shows", "HomeId");
            DropTable("dbo.Homes");
        }
    }
}
