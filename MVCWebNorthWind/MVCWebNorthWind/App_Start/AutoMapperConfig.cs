using AutoMapper;
using MVCWebNorthWind.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebNorthWind.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize
            (
                cfg =>
                {
                    cfg.AddProfile<ServiceMappingProfile>();
                }
            );
        }
    }
}