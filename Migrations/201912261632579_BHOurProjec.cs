namespace BHOurProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BHOurProjec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarrierForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        MailAddress = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        MilitaryStatus = c.Boolean(nullable: false),
                        Note = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(),
                        Image = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Image = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ColorPickers",
                c => new
                    {
                        Is = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Rgb = c.String(),
                    })
                .PrimaryKey(t => t.Is);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Department = c.String(),
                        Image = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Fax = c.String(),
                        MapPath = c.String(),
                        DetailInformation = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Machines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Image = c.String(),
                        Date = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.References",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Image = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyRepresentative = c.String(),
                        PhoneNumber = c.String(),
                        TaxNumber = c.String(),
                        MailAddress = c.String(),
                        ProductOfInterest = c.String(),
                        Quantity = c.Double(nullable: false),
                        City = c.String(),
                        Explanation = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Machines", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Machines", new[] { "CompanyId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.RequestForms");
            DropTable("dbo.References");
            DropTable("dbo.News");
            DropTable("dbo.Machines");
            DropTable("dbo.Companies");
            DropTable("dbo.ColorPickers");
            DropTable("dbo.Certificates");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.CarrierForms");
        }
    }
}
