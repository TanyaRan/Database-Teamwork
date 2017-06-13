namespace Bookstore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_Author_Name");
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        GenreId = c.Int(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .Index(t => t.GenreId)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Authors", "IX_Author_Name");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
