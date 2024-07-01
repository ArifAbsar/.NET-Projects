namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Meeting_Minutes_Details_tbl", name: "MeetingMinutes_Id", newName: "Meeting_Minutes_Master_tbl_Id");
            RenameIndex(table: "dbo.Meeting_Minutes_Details_tbl", name: "IX_MeetingMinutes_Id", newName: "IX_Meeting_Minutes_Master_tbl_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Meeting_Minutes_Details_tbl", name: "IX_Meeting_Minutes_Master_tbl_Id", newName: "IX_MeetingMinutes_Id");
            RenameColumn(table: "dbo.Meeting_Minutes_Details_tbl", name: "Meeting_Minutes_Master_tbl_Id", newName: "MeetingMinutes_Id");
        }
    }
}
