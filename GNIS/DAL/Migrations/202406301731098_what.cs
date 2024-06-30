namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class what : DbMigration
    {
        public override void Up()
        {
            if (!Sql("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Individual_customer_tbl'").Any())
            {
                CreateTable(
                    "dbo.Individual_customer_tbl",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Individual_Customer_Name = c.String(),
                        // Add other properties here
                    })
                    .PrimaryKey(t => t.Id);
            }
        }

        public override void Down()
        {
            DropTable("dbo.Individual_customer_tbl");
        }

    }
}
