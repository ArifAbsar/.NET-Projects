using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting.Models
{
    public class MeetingMinutesViewModel
    {
        public MeetingMinutesMaster Master { get; set; }
        public List<MeetingMinutesDetail> Details { get; set; }
        public IEnumerable<CorporateCustomer> CorporateCustomers { get; set; }
        public IEnumerable<IndividualCustomer> IndividualCustomers { get; set; }
        public IEnumerable<ProductService> ProductServices { get; set; }
    }
}