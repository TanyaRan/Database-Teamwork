namespace ToysShop.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        FullAddress = c.String(nullable: false, maxLength: 250),
                        CustomerId = c.Int(),
                        VendorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Region = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        AddressId = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.ProductOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 70),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        SuitabaleFor = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 7, scale: 2),
                        UnitsInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        ParentCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 70),
                        AddressId = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Offer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        OfferDate = c.DateTime(nullable: false),
                        TradePrice = c.Decimal(nullable: false, precision: 7, scale: 2),
                        IsOutdated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Vendor", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductVendor",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Vendor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Vendor_Id })
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Vendor", t => t.Vendor_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Vendor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendor", "Id", "dbo.Address");
            DropForeignKey("dbo.Customer", "Id", "dbo.Address");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ProductOrder", "OrderId", "dbo.Order");
            DropForeignKey("dbo.ProductVendor", "Vendor_Id", "dbo.Vendor");
            DropForeignKey("dbo.ProductVendor", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Offer", "VendorId", "dbo.Vendor");
            DropForeignKey("dbo.Offer", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductOrder", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Category", "ParentCategoryId", "dbo.Category");
            DropForeignKey("dbo.Address", "CityId", "dbo.City");
            DropIndex("dbo.ProductVendor", new[] { "Vendor_Id" });
            DropIndex("dbo.ProductVendor", new[] { "Product_Id" });
            DropIndex("dbo.Offer", new[] { "ProductId" });
            DropIndex("dbo.Offer", new[] { "VendorId" });
            DropIndex("dbo.Vendor", new[] { "Name" });
            DropIndex("dbo.Vendor", new[] { "Id" });
            DropIndex("dbo.Category", new[] { "ParentCategoryId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.Product", new[] { "Name" });
            DropIndex("dbo.ProductOrder", new[] { "ProductId" });
            DropIndex("dbo.ProductOrder", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.Customer", new[] { "Id" });
            DropIndex("dbo.Address", new[] { "CityId" });
            DropTable("dbo.ProductVendor");
            DropTable("dbo.Offer");
            DropTable("dbo.Vendor");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.ProductOrder");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
            DropTable("dbo.City");
            DropTable("dbo.Address");
        }
    }
}
