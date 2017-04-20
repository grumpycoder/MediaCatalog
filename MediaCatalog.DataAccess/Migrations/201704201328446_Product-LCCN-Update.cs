namespace MediaCatalog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductLCCNUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "LCCN", c => c.String(maxLength: 25, unicode: false));
            DropColumn("dbo.Products", "LibraryCongressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "LibraryCongressId", c => c.String(maxLength: 25, unicode: false));
            DropColumn("dbo.Products", "LCCN");
        }
    }
}
