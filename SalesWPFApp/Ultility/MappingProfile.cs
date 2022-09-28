using AutoMapper;
using BusinessObject;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWPFApp.Ultility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberObject>();
            CreateMap<Order, OrderObject>();
            CreateMap<OrderDetail, OrderDetailObject>();
            CreateMap<Product, ProductObject>();
            CreateMap<MemberObject, Member>();
            CreateMap<OrderObject, Order>();
            CreateMap<OrderDetailObject, OrderDetail>();
            CreateMap<ProductObject, Product>();
        }
    }
}
