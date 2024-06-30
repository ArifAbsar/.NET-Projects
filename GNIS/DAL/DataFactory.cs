using DAL.EF.Tables;
using DAL.Interface;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class DataFactory
    {
        public static IRepo<Corporate_customer_tbl, int> CoporateData()
        {
            return new CorporateRepo();
        }
        public static IRepo<Individual_customer_tbl, int> IndividualData()
        {
            return new IndividualRepo();
        }
        public static IRepo<Product_Service_tbl, int> ProdData()
        {
            return new Prod_ServiceRepo();
        }
    }
}
