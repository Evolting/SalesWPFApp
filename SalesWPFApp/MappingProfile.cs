using AutoMapper;
using BusinessObject;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWPFApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberObject>();
            CreateMap<Order, OrderObject>();
            CreateMap<Product, ProductObject>();
        }
    }
}
