using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class Product_Service
    {
        public static List<Product_ServiceDTO> Get()
        {
            var data = DataFactory.CoporateData().Get(); //List<Course> ef model

            //mapper
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product_Service_tbl, Product_ServiceDTO>();
            });
            var mapper = new Mapper(config);
            var retdata = mapper.Map<List<Product_ServiceDTO>>(data);


            return retdata;
        }
    }
}
