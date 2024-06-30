using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    internal class MeetingContext: DbContext
    {
        public MeetingContext():base("name=MeetContext"){}
        public DbSet<Corporate_customer_tbl>Corporates { get; set; }
        public DbSet<Individual_customer_tbl > Individuals { get; set; }
        public DbSet<Meeting_Minutes_Details_tbl> Meetings { get; set; }
        public DbSet<Meeting_Minutes_Master_tbl> MeetingsMaster { get; set;}
        public DbSet<Product_Service_tbl> Products { get; set; }
    }
}