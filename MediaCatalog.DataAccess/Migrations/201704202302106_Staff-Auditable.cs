namespace MediaCatalog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StaffAuditable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "DateCreated", c => c.DateTime(storeType: "smalldatetime"));
            AddColumn("dbo.Staffs", "DateModified", c => c.DateTime(storeType: "smalldatetime"));
            AddColumn("dbo.Staffs", "CreatedUser", c => c.String(maxLength: 255, unicode: false));
            AddColumn("dbo.Staffs", "ModifiedUser", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staffs", "ModifiedUser");
            DropColumn("dbo.Staffs", "CreatedUser");
            DropColumn("dbo.Staffs", "DateModified");
            DropColumn("dbo.Staffs", "DateCreated");
        }
    }
}
