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
        public Nullable<int> Restid { get; set; }
        public string PreserveTime { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public Nullable<int> Received_By { get; set; }
        public Nullable<int> Approved_by { get; set; }
        public Nullable<System.DateTime> CollectDate { get; set; }

    }
}