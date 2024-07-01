using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Product_Service_tbl
    {
        public int id { get; set; }
        public string Prod_Name { get; set; }
        public int Quantity {  get; set; }
        public string unit {  get; set; }
    }
}
