namespace pegatronb2b.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeType = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CodeType, unique: true);
            
            CreateTable(
                "dbo.CodeItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 20),
                        Text = c.String(nullable: false, maxLength: 20),
                        BaseCodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseCodes", t => t.BaseCodeId, cascadeDelete: true)
                .Index(t => new { t.Code, t.BaseCodeId }, unique: true, name: "CodeItem_IX");
            
            CreateTable(
                "dbo.DataTableImportMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntitySetName = c.String(nullable: false, maxLength: 50),
                        FieldName = c.String(nullable: false, maxLength: 50),
                        DefaultValue = c.String(maxLength: 50),
                        TypeName = c.String(maxLength: 30),
                        IsRequired = c.Boolean(nullable: false),
                        SourceFieldName = c.String(maxLength: 50),
                        IsEnabled = c.Boolean(nullable: false),
                        RegularExpression = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.EntitySetName, t.FieldName }, unique: true, name: "IX_DataTableImportMapping");
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 100),
                        Code = c.String(nullable: false, maxLength: 20),
                        Url = c.String(nullable: false, maxLength: 100),
                        Controller = c.String(maxLength: 100),
                        Action = c.String(maxLength: 100),
                        IconCls = c.String(maxLength: 50),
                        IsEnabled = c.Boolean(nullable: false),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItems", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.RoleMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 20),
                        MenuId = c.Int(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        Create = c.Boolean(nullable: false),
                        Edit = c.Boolean(nullable: false),
                        Delete = c.Boolean(nullable: false),
                        Import = c.Boolean(nullable: false),
                        Export = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItems", t => t.MenuId, cascadeDelete: true)
                .Index(t => new { t.RoleName, t.MenuId }, unique: true, name: "IX_rolemenu");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleMenus", "MenuId", "dbo.MenuItems");
            DropForeignKey("dbo.MenuItems", "ParentId", "dbo.MenuItems");
            DropForeignKey("dbo.CodeItems", "BaseCodeId", "dbo.BaseCodes");
            DropIndex("dbo.RoleMenus", "IX_rolemenu");
            DropIndex("dbo.MenuItems", new[] { "ParentId" });
            DropIndex("dbo.DataTableImportMappings", "IX_DataTableImportMapping");
            DropIndex("dbo.CodeItems", "CodeItem_IX");
            DropIndex("dbo.BaseCodes", new[] { "CodeType" });
            DropTable("dbo.RoleMenus");
            DropTable("dbo.MenuItems");
            DropTable("dbo.DataTableImportMappings");
            DropTable("dbo.CodeItems");
            DropTable("dbo.BaseCodes");
        }
    }
}
