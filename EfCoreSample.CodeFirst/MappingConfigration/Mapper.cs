using AutoMapper;
using EfCoreSample.CodeFirst.DAL;
using EfCoreSample.CodeFirst.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.CodeFirst.MappingConfigration
{
    public static class ObjectMapper 
    {

        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapper>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper()
        {
            return lazy.Value;
        }
    }
    internal class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Customer, CustomerDto>(); 
        }
    }
}
