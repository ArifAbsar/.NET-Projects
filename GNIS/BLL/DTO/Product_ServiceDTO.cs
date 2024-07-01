using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class Product_ServiceDTO
    {
        public int id { get; set; }
        public string Prod_Name { get; set; }
        public int Quantity { get; set; }
        public string unit { get; set; }
    }
}
