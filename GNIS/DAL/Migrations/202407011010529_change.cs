namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Meeting_Minutes_Master_tbl", "MeetingDate", c => c.String());
            AlterColumn("dbo.Meeting_Minutes_Master_tbl", "MeetingTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Meeting_Minutes_Master_tbl", "MeetingTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Meeting_Minutes_Master_tbl", "MeetingDate", c => c.DateTime(nullable: false));
        }
    }
}
