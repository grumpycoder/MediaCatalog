namespace MediaCatalog.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class publishers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publishers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 150, unicode: false),
                    WebsiteUrl = c.String(maxLength: 256, unicode: false),
                    Email = c.String(maxLength: 125, unicode: false),
                    Street = c.String(maxLength: 75, unicode: false),
                    Street2 = c.String(maxLength: 75, unicode: false),
                    City = c.String(maxLength: 100, unicode: false),
                    State = c.String(maxLength: 2, unicode: false),
                    Zipcode = c.String(maxLength: 12, unicode: false),
                    Phone = c.String(maxLength: 12, unicode: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Publishers");
        }
    }
}
