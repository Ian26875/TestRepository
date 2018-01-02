using AutoMapper;
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
            CreateMap<Customers, Customers>();
        }
    }
}