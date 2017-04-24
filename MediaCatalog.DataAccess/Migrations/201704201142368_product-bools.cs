namespace MediaCatalog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productbools : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Reviewed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "Purchased", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "Donated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Donated", c => c.Boolean());
            AlterColumn("dbo.Products", "Purchased", c => c.Boolean());
            AlterColumn("dbo.Products", "Reviewed", c => c.Boolean());
        }
    }
}
