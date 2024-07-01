namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prodcol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product_Service_tbl", "unit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product_Service_tbl", "unit");
        }
    }
}
