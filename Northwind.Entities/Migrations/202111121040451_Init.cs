namespace Northwind.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 15),
                        Description = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        UpdatedById = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 40),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        QuantityPerUnit = c.String(maxLength: 20),
                        Discontinued = c.Boolean(nullable: false),
                        CategoryId = c.Int(),
                        SupplierId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        UpdatedById = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.CategoryId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Order Details",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Short(nullable: false),
                        Discount = c.Single(nullable: false),
                        Order_OrderId = c.Int(),
                        Order_OrderId1 = c.Int(),
                        Product_Id = c.Int(),
                        Product_Id1 = c.Int(),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId1)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id1)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Order_OrderId1)
                .Index(t => t.Product_Id)
                .Index(t => t.Product_Id1);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        RequiredDate = c.DateTime(),
                        ShippedDate = c.DateTime(),
                        Freight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShipAddress = c.String(nullable: false, maxLength: 60),
                        EmployeeId = c.Int(),
                        ShipVia = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Shippers", t => t.ShipVia)
                .Index(t => t.EmployeeId)
                .Index(t => t.ShipVia);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        Title = c.String(maxLength: 30),
                        BirthDate = c.DateTime(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 60),
                        Phone = c.String(maxLength: 24),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        UpdatedById = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(maxLength: 24),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        UpdatedById = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 40),
                        ContactName = c.String(maxLength: 30),
                        ContactTitle = c.String(maxLength: 30),
                        Address = c.String(maxLength: 60),
                        Phone = c.String(maxLength: 24),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        UpdatedById = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 12),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        UpdatedById = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Order Details", "Product_Id1", "dbo.Products");
            DropForeignKey("dbo.Order Details", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Order Details", "Order_OrderId1", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ShipVia", "dbo.Shippers");
            DropForeignKey("dbo.Order Details", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "ShipVia" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Order Details", new[] { "Product_Id1" });
            DropIndex("dbo.Order Details", new[] { "Product_Id" });
            DropIndex("dbo.Order Details", new[] { "Order_OrderId1" });
            DropIndex("dbo.Order Details", new[] { "Order_OrderId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Users");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Shippers");
            DropTable("dbo.Employees");
            DropTable("dbo.Orders");
            DropTable("dbo.Order Details");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
