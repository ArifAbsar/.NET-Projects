using DAL.EF.Tables;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CorporateRepo : Repo, IRepo<Corporate_customer_tbl, int>
    {
        public void Create(Corporate_customer_tbl obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Corporate_customer_tbl> Get()
        {
            return db.Corporates.ToList();
        }

        public Corporate_customer_tbl Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Corporate_customer_tbl obj)
        {
            throw new NotImplementedException();
        }
    }
}
