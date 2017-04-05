namespace MediaCatalog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(maxLength: 75, unicode: false),
                        Lastname = c.String(maxLength: 125, unicode: false),
                        Email = c.String(maxLength: 125, unicode: false),
                        Role = c.String(maxLength: 50, unicode: false),
                        Street = c.String(maxLength: 75, unicode: false),
                        Street2 = c.String(maxLength: 75, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        State = c.String(maxLength: 2, unicode: false),
                        Zipcode = c.String(maxLength: 12, unicode: false),
                        Phone = c.String(maxLength: 12, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StaffProducts",
                c => new
                    {
                        StaffId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StaffId, t.ProductId })
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.StaffId, name: "IX_Staff_Id")
                .Index(t => t.ProductId, name: "IX_Product_Id");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaffProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.StaffProducts", "StaffId", "dbo.Staffs");
            DropIndex("dbo.StaffProducts", "IX_Product_Id");
            DropIndex("dbo.StaffProducts", "IX_Staff_Id");
            DropTable("dbo.StaffProducts");
            DropTable("dbo.Staffs");
        }
    }
}
