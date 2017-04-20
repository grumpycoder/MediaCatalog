namespace MediaCatalog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductAuditable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DateCreated", c => c.DateTime(storeType: "smalldatetime"));
            AddColumn("dbo.Products", "DateModified", c => c.DateTime(storeType: "smalldatetime"));
            AddColumn("dbo.Products", "CreatedUser", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Products", "ModifiedUser", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ModifiedUser");
            DropColumn("dbo.Products", "CreatedUser");
            DropColumn("dbo.Products", "DateModified");
            DropColumn("dbo.Products", "DateCreated");
        }
    }
}
