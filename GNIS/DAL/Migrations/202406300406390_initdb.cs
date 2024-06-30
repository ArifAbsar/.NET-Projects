namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Corporate_customer_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Corporate_Customer_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Individual_customer_tbl",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Customer_Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Meeting_Minutes_Details_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeetingMinutesId = c.Int(nullable: false),
                        ProductServiceId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meeting_Minutes_Master_tbl", t => t.MeetingMinutesId, cascadeDelete: true)
                .Index(t => t.MeetingMinutesId);
            
            CreateTable(
                "dbo.Meeting_Minutes_Master_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerType = c.String(),
                        MeetingDate = c.DateTime(nullable: false),
                        MeetingTime = c.Time(nullable: false, precision: 7),
                        MeetingPlace = c.String(),
                        AttendsFromClientSide = c.String(),
                        AttendsFromHostSide = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meeting_Minutes_Details_tbl", "MeetingMinutesId", "dbo.Meeting_Minutes_Master_tbl");
            DropIndex("dbo.Meeting_Minutes_Details_tbl", new[] { "MeetingMinutesId" });
            DropTable("dbo.Meeting_Minutes_Master_tbl");
            DropTable("dbo.Meeting_Minutes_Details_tbl");
            DropTable("dbo.Individual_customer_tbl");
            DropTable("dbo.Corporate_customer_tbl");
        }
    }
}
