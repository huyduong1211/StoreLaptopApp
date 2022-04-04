namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTableShowDayShowTime : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shows", "ShowDayId", "dbo.ShowDays");
            DropForeignKey("dbo.Shows", "ShowTimeId", "dbo.ShowTimes");
            DropIndex("dbo.Shows", new[] { "ShowDayId" });
            DropIndex("dbo.Shows", new[] { "ShowTimeId" });
            DropColumn("dbo.Shows", "ShowDayId");
            DropColumn("dbo.Shows", "ShowTimeId");
            DropTable("dbo.ShowDays");
            DropTable("dbo.ShowTimes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShowTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShowDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Shows", "ShowTimeId", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "ShowDayId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shows", "ShowTimeId");
            CreateIndex("dbo.Shows", "ShowDayId");
            AddForeignKey("dbo.Shows", "ShowTimeId", "dbo.ShowTimes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Shows", "ShowDayId", "dbo.ShowDays", "Id", cascadeDelete: true);
        }
    }
}
