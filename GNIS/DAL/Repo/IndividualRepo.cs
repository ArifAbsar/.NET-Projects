using DAL.EF;
using DAL.EF.Tables;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class IndividualRepo : Repo, IRepo<Individual_customer_tbl, int>
    {
        private readonly MeetingContext dab = new MeetingContext();
        public void Create(Individual_customer_tbl obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Individual_customer_tbl> Get()
        {
            return dab.Individuals.ToList();
        }

        public Individual_customer_tbl Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Individual_customer_tbl obj)
        {
            throw new NotImplementedException();
        }
    }
}
