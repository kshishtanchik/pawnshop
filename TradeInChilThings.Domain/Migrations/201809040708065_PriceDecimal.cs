namespace TradeInChilThings.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Things", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Things", "Price", c => c.Double(nullable: false));
        }
    }
}
