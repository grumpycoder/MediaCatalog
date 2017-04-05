namespace MediaCatalog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class securityupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Fullname", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Fullname");
        }
    }
}
