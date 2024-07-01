using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    internal class Meeting_Minutes_DetailsDTO
    {
        public int Id { get; set; }
        public int MeetingMinutesId { get; set; }
        public int ProductServiceId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public virtual Meeting_Minutes_Master_tbl MeetingMinutes { get; set; }
    }
}
