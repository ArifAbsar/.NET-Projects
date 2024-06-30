namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getpro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product_Service_tbl", "Prod_Name", c => c.String());
            DropColumn("dbo.Product_Service_tbl", "Product_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product_Service_tbl", "Product_Name", c => c.String());
            DropColumn("dbo.Product_Service_tbl", "Prod_Name");
        }
    }
}
