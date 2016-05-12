namespace pegatronb2b.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sku : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PgaSkus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sku = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
                        StoreKey = c.String(nullable: false, maxLength: 30),
                        Keeper = c.String(nullable: false, maxLength: 50),
                        Warehouse = c.String(nullable: false, maxLength: 50),
                        MOQ = c.Int(nullable: false),
                        LotNo = c.String(maxLength: 50),
                        Mo = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 30),
                        ModifiedBy = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PgaSkus");
        }
    }
}
