namespace pegatronb2b.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kittings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PgaKittings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeqId = c.String(nullable: false, maxLength: 50),
                        Plant = c.String(nullable: false, maxLength: 30),
                        HubId = c.String(maxLength: 30),
                        PdLine = c.String(maxLength: 30),
                        TransType = c.String(maxLength: 10),
                        MO = c.String(maxLength: 50),
                        Stage = c.String(maxLength: 50),
                        ItemNo = c.String(maxLength: 10),
                        Material = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        Keeper = c.String(maxLength: 30),
                        FromWH = c.String(maxLength: 30),
                        ToWH = c.String(maxLength: 30),
                        RequestQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Building = c.String(maxLength: 30),
                        Dock = c.String(maxLength: 30),
                        RequestDate = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 50),
                        LotNo = c.String(maxLength: 50),
                        UDNo = c.String(maxLength: 50),
                        CloseDateTime = c.DateTime(),
                        KittingId = c.String(maxLength: 50),
                        OrderKey = c.String(maxLength: 30),
                        StoreKey = c.String(maxLength: 20),
                        ShipDate = c.String(maxLength: 20),
                        ShipQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderStatus = c.String(maxLength: 10),
                        Status = c.String(maxLength: 10),
                        Remark1 = c.String(maxLength: 50),
                        Note = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 10),
                        TrailerNumber = c.String(maxLength: 10),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        ModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SeqId, unique: true, name: "IDX_kitting_SEQID");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PgaKittings", "IDX_kitting_SEQID");
            DropTable("dbo.PgaKittings");
        }
    }
}
