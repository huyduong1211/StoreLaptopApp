namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdAccount = c.String(),
                        NameAccount = c.String(),
                        Content = c.String(),
                        Note = c.Int(nullable: false),
                        Day = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ProductId", "dbo.Products");
            DropIndex("dbo.Comments", new[] { "ProductId" });
            DropTable("dbo.Comments");
        }
    }
}
