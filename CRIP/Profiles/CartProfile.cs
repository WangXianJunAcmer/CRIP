using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRIP.Dtos;
using CRIP.Models;

namespace Tourist.Profiles
{
    public class CartProfile:Profile
    {
        public CartProfile()
        {
            CreateMap<AddCartItemDto, LineItem>();
            CreateMap<LineItem, LineItemDto>();
            CreateMap<DeleteCartItemDto, LineItem>();
            CreateMap<Cart,CartDto>();
        }
    }
}
