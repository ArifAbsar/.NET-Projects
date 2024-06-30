using DAL.EF.Tables;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class IndividualRepo : Repo, IRepo<individual_customer_tbl, int>
    {
        public void Create(individual_customer_tbl obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<individual_customer_tbl> Get()
        {
            return db.Individuals.ToList();
        }

        public individual_customer_tbl Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(individual_customer_tbl obj)
        {
            throw new NotImplementedException();
        }
    }
}
