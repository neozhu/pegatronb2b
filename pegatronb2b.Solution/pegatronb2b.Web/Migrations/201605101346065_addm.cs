namespace pegatronb2b.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PgaGrs", "ReceiptType", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PgaGrs", "ReceiptType", c => c.String());
        }
    }
}
