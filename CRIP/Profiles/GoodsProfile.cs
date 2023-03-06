using AutoMapper;
using CRIP.Dtos;
using CRIP.Dtos.GoodsDtos;
using CRIP.Models;

namespace CRIP.Profiles
{
    public class GoodsProfile:Profile
    {
      public  GoodsProfile() {
            CreateMap<Goods, GoodsDto>();
            CreateMap<GoodsCreateDto, Goods>();
            CreateMap<Goods,GoodsUpdateDto>();
            CreateMap<Goods, GoodsSimplifyDto>();
            CreateMap<GoodsUpdateDto,Goods>();
        }
    }
}
