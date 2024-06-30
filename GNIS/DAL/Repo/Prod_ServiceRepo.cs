using DAL.EF.Tables;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class Prod_ServiceRepo : Repo, IRepo<Product_Service_tbl, int>
    {
        public void Create(Product_Service_tbl obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product_Service_tbl> Get()
        {
            return db.Products.ToList();
        }

        public Product_Service_tbl Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product_Service_tbl obj)
        {
            throw new NotImplementedException();
        }
    }
}
