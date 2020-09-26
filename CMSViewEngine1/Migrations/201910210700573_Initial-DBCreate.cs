namespace CMSViewEngine1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDBCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PageTitle = c.String(nullable: false),
                        PageType = c.Int(nullable: false),
                        Layout = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PageLayouts", t => t.PageType, cascadeDelete: true)
                .Index(t => t.PageType);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        PageContent = c.String(),
                        AddedDate = c.DateTime(),
                        PageLayout_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainPages", t => t.PageID, cascadeDelete: true)
                .ForeignKey("dbo.PageLayouts", t => t.PageLayout_Id)
                .Index(t => t.PageID)
                .Index(t => t.PageLayout_Id);
            
            CreateTable(
                "dbo.PageLayouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PageTitle = c.String(nullable: false),
                        Template = c.String(),
                        Top = c.String(),
                        Bottom = c.String(),
                        MainPage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainPages", t => t.MainPage_Id)
                .Index(t => t.MainPage_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageLayouts", "MainPage_Id", "dbo.MainPages");
            DropForeignKey("dbo.MainPages", "PageType", "dbo.PageLayouts");
            DropForeignKey("dbo.Contents", "PageLayout_Id", "dbo.PageLayouts");
            DropForeignKey("dbo.Contents", "PageID", "dbo.MainPages");
            DropIndex("dbo.PageLayouts", new[] { "MainPage_Id" });
            DropIndex("dbo.Contents", new[] { "PageLayout_Id" });
            DropIndex("dbo.Contents", new[] { "PageID" });
            DropIndex("dbo.MainPages", new[] { "PageType" });
            DropTable("dbo.PageLayouts");
            DropTable("dbo.Contents");
            DropTable("dbo.MainPages");
        }
    }
}
