namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initprod : DbMigration
    {
        public override void Up()
        {
           
            
            CreateTable(
                "dbo.Product_Service_tbl",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Prod_Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Individual_customer_tbl",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Customer_Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.Product_Service_tbl");
            
        }
    }
}
