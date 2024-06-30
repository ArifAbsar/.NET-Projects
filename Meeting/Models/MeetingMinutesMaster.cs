using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting.Models
{
    public class MeetingMinutesMaster
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerType { get; set; }
        public DateTime Date { get; set; }
        public string MeetingPlace { get; set; }
        public string AttendsFromClientSide { get; set; }
        public string AttendsFromHostSide { get; set; }
        public string MeetingAgenda { get; set; }
        public string MeetingDiscussion { get; set; }
        public string MeetingDecision { get; set; }
    }
}