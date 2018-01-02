using AutoMapper;
using MVCWebNorthWind.DTOs;
using MVCWebNorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebNorthWind.Mappings
{
    public class ServiceMappingProfile:Profile
    {
        public ServiceMappingProfile()
        {
            MappingInitialize();
        }

        private void MappingInitialize()
        {
            CreateMap<Customers, CustomerDTO>();
            CreateMap<CustomerDTO, Customers>();
            CreateMap<Orders, OrderDTO>();
            CreateMap<OrderDTO, Orders>();
        }
    }
}