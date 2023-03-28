using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRIP.Dtos;
using CRIP.Models;

namespace CRIP.Profiles
{
    public class OrderProfile:Profile   
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
