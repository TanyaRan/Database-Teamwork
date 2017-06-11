namespace ToysShop.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ProductWithImageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ImageUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ImageUrl");
        }
    }
}
