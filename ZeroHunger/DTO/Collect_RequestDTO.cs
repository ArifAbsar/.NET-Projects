using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger.EF;

namespace ZeroHunger.DTO
{
    public class Collect_RequestDTO
    {
        public int Collectid { get; set; }
        public int Restid { get; set; }
        public string PreserveTime { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int Received_By { get; set; }
        public string Approved_by { get; set; }
        public System.DateTime CollectDate { get; set; }
        public virtual User User { get; set; }
        public virtual Resturant Resturant { get; set; }
        public virtual User User1 { get; set; }
        
    }
}