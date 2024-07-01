namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class helllllppppp : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Individual_customer_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
          ;
            
            
         
            
        }
        
        public override void Down()
        {
            
            DropTable("dbo.Individual_customer_tbl");
           
        }
    }
}
