using AutoMapper;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interface;
using DAL.Repo;
using DAL.EF.Tables;

namespace BLL.Services
{
    public static class Corporate_Service
    {
        public static List<Corporate_CustomerDTO> GetCorp()
        {
            var data = DataFactory.CoporateData().Get(); //List<Course> ef model

            //mapper
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Corporate_customer_tbl, Corporate_CustomerDTO>();
            });
            var mapper = new Mapper(config);
            var retdata = mapper.Map<List<Corporate_CustomerDTO>>(data);


            return retdata;
        }
    }
}
