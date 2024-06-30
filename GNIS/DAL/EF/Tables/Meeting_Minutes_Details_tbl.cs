using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Meeting_Minutes_Details_tbl
    {
        public int Id { get; set; }
        public int MeetingMinutesId { get; set; }
        public int ProductServiceId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public virtual Meeting_Minutes_Master_tbl MeetingMinutes { get; set; }
    }
}
