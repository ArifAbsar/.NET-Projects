namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeprod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product_Service_tbl", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product_Service_tbl", "Quantity");
        }
    }
}
