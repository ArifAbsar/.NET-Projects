using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting.Models
{
    public class MeetingMinutesDetail
    {
        public int Id { get; set; }
        public int MeetingMinutesMasterId { get; set; }
        public int ProductServiceId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }
}