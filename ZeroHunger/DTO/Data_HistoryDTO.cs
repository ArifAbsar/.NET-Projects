using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger.EF;

namespace ZeroHunger.DTO
{
    public class Data_HistoryDTO
    {
        public string Histid { get; set; }
        public int Restid { get; set; }
        public int Collectid { get; set; }
        public string PreserveTime { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int Received_By { get; set; }
        public string Approved_By { get; set; }
        public virtual Collect_Request Collect_Request { get; set; }
        public virtual Resturant Resturant { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        
       
    }
}