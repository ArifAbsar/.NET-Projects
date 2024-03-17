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
        public Nullable<int> Received_By { get; set; }
        public Nullable<int> Approved_By { get; set; }


    }
}