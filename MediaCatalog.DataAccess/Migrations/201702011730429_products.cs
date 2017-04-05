namespace MediaCatalog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class products : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ISBN = c.String(maxLength: 8000, unicode: false),
                        Title = c.String(maxLength: 8000, unicode: false),
                        Summary = c.String(maxLength: 8000, unicode: false),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PublisherId", "dbo.Publishers");
            DropIndex("dbo.Products", new[] { "PublisherId" });
            DropTable("dbo.Products");
        }
    }
}
