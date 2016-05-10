namespace pegatronb2b.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pgagr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PgaGrs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UDNo = c.String(nullable: false, maxLength: 50),
                        Material = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrDate = c.String(nullable: false, maxLength: 20),
                        Warehouse = c.String(maxLength: 50),
                        RC = c.String(maxLength: 250),
                        Plant = c.String(maxLength: 50),
                        Vendor = c.String(nullable: false, maxLength: 50),
                        GRNo = c.String(nullable: false, maxLength: 50),
                        GRItem = c.String(maxLength: 10),
                        Area = c.String(maxLength: 50),
                        Brand = c.String(maxLength: 50),
                        TransmitId = c.String(nullable: false, maxLength: 50),
                        StoreKey = c.String(nullable: false, maxLength: 20),
                        ReceiptKey = c.String(maxLength: 30),
                        ReceiptDate = c.DateTime(),
                        QtyReceived = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(maxLength: 10),
                        Susr1 = c.String(maxLength: 20),
                        Susr2 = c.String(maxLength: 20),
                        ReceiptType = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        ModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PgaGrs");
        }
    }
}
