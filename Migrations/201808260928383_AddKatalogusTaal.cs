namespace Biblioteek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKatalogusTaal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Katalogus",
                c => new
                    {
                        Jaar = c.Int(nullable: false),
                        Nommer = c.Int(nullable: false),
                        Genre = c.Int(nullable: false),
                        OuderdomsGroep = c.Int(nullable: false),
                        Skrywer = c.String(),
                        Tietel = c.String(),
                        Dewey = c.String(),
                        Taal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Jaar, t.Nommer });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Katalogus");
        }
    }
}
