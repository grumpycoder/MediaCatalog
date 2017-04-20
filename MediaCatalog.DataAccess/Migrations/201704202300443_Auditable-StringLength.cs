namespace MediaCatalog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuditableStringLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "CreatedUser", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Products", "ModifiedUser", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Publishers", "CreatedUser", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Publishers", "ModifiedUser", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publishers", "ModifiedUser", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Publishers", "CreatedUser", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Products", "ModifiedUser", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Products", "CreatedUser", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
