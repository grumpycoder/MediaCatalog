namespace MediaCatalog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productauthorlocid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Author", c => c.String(maxLength: 255, unicode: false));
            AddColumn("dbo.Products", "LibraryCongressId", c => c.String(maxLength: 25, unicode: false));
            AddColumn("dbo.Products", "ReceiptDate", c => c.DateTime(storeType: "smalldatetime"));
            AddColumn("dbo.Products", "Reviewed", c => c.Boolean());
            AddColumn("dbo.Products", "Purchased", c => c.Boolean());
            AddColumn("dbo.Products", "Donated", c => c.Boolean());
            AlterColumn("dbo.Products", "ISBN", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Products", "Title", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Products", "Summary", c => c.String(maxLength: 1024, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Summary", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Products", "Title", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Products", "ISBN", c => c.String(maxLength: 8000, unicode: false));
            DropColumn("dbo.Products", "Donated");
            DropColumn("dbo.Products", "Purchased");
            DropColumn("dbo.Products", "Reviewed");
            DropColumn("dbo.Products", "ReceiptDate");
            DropColumn("dbo.Products", "LibraryCongressId");
            DropColumn("dbo.Products", "Author");
        }
    }
}
