namespace TradeInChilThings.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TelephoneNumer = c.String(),
                        Addreess = c.String(),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Picture = c.Binary(),
                        ThingId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Things", t => t.ThingId)
                .Index(t => t.ThingId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThingId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Things", t => t.ThingId, cascadeDelete: true)
                .Index(t => t.ThingId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Things",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfReceipt = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        CategoryId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ThingId", "dbo.Things");
            DropForeignKey("dbo.Images", "ThingId", "dbo.Things");
            DropForeignKey("dbo.Things", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Things", new[] { "CategoryId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "ThingId" });
            DropIndex("dbo.Images", new[] { "ThingId" });
            DropTable("dbo.Things");
            DropTable("dbo.Orders");
            DropTable("dbo.Images");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
        }
    }
}
