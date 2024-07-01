using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class Meeting_Minutes_MasterDTO
    {
        public int Id { get; set; }
        public string CustomerType { get; set; }
        public string MeetingDate { get; set; }
        public string MeetingTime { get; set; }
        public string MeetingPlace { get; set; }
        public string AttendsFromClientSide { get; set; }
        public string AttendsFromHostSide { get; set; }
        public ICollection<Meeting_Minutes_Details_tbl> ProductsServices { get; set; }
    }
}
