namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class del : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meeting_Minutes_Details_tbl", "MeetingMinutesId", "dbo.Meeting_Minutes_Master_tbl");
            DropIndex("dbo.Meeting_Minutes_Details_tbl", new[] { "MeetingMinutesId" });
            RenameColumn(table: "dbo.Meeting_Minutes_Details_tbl", name: "MeetingMinutesId", newName: "MeetingMinutes_Id");
            AlterColumn("dbo.Meeting_Minutes_Details_tbl", "MeetingMinutes_Id", c => c.Int());
            CreateIndex("dbo.Meeting_Minutes_Details_tbl", "MeetingMinutes_Id");
            AddForeignKey("dbo.Meeting_Minutes_Details_tbl", "MeetingMinutes_Id", "dbo.Meeting_Minutes_Master_tbl", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meeting_Minutes_Details_tbl", "MeetingMinutes_Id", "dbo.Meeting_Minutes_Master_tbl");
            DropIndex("dbo.Meeting_Minutes_Details_tbl", new[] { "MeetingMinutes_Id" });
            AlterColumn("dbo.Meeting_Minutes_Details_tbl", "MeetingMinutes_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Meeting_Minutes_Details_tbl", name: "MeetingMinutes_Id", newName: "MeetingMinutesId");
            CreateIndex("dbo.Meeting_Minutes_Details_tbl", "MeetingMinutesId");
            AddForeignKey("dbo.Meeting_Minutes_Details_tbl", "MeetingMinutesId", "dbo.Meeting_Minutes_Master_tbl", "Id", cascadeDelete: true);
        }
    }
}
