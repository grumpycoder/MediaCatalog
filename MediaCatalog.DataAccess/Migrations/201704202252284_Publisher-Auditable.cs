namespace MediaCatalog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublisherAuditable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publishers", "DateCreated", c => c.DateTime(storeType: "smalldatetime"));
            AddColumn("dbo.Publishers", "DateModified", c => c.DateTime(storeType: "smalldatetime"));
            AddColumn("dbo.Publishers", "CreatedUser", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Publishers", "ModifiedUser", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publishers", "ModifiedUser");
            DropColumn("dbo.Publishers", "CreatedUser");
            DropColumn("dbo.Publishers", "DateModified");
            DropColumn("dbo.Publishers", "DateCreated");
        }
    }
}
