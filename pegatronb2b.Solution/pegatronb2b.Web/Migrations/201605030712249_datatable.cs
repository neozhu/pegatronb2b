namespace pegatronb2b.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataTableImportMappings", "FieldDesc", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataTableImportMappings", "FieldDesc");
        }
    }
}
