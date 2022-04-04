namespace StoreLaptopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTableGioHang : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.GioHangs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaTK = c.String(),
                        MaSP = c.String(),
                        Name = c.String(),
                        SoLuong = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        TongTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
