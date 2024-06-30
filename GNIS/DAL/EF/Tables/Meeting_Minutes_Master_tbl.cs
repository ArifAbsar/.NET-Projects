using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Meeting_Minutes_Master_tbl
    {
        public int Id { get; set; }
        public string CustomerType { get; set; }
        public DateTime MeetingDate { get; set; }
        public TimeSpan MeetingTime { get; set; }
        public string MeetingPlace { get; set; }
        public string AttendsFromClientSide { get; set; }
        public string AttendsFromHostSide { get; set; }
        public ICollection<Meeting_Minutes_Details_tbl> ProductsServices { get; set; }
    }
}
