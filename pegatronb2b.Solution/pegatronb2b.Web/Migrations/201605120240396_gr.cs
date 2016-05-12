namespace pegatronb2b.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PgaGrs", "Remark1", c => c.String(maxLength: 100));
            AddColumn("dbo.PgaGrs", "Remark2", c => c.String(maxLength: 100));
            AddColumn("dbo.PgaGrs", "ReceiptStatus", c => c.String(maxLength: 10));
            AddColumn("dbo.PgaGrs", "Result", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PgaGrs", "Result");
            DropColumn("dbo.PgaGrs", "ReceiptStatus");
            DropColumn("dbo.PgaGrs", "Remark2");
            DropColumn("dbo.PgaGrs", "Remark1");
        }
    }
}
