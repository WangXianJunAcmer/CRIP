using AutoMapper;
using CRIP.Dtos;
using CRIP.Dtos;
using CRIP.Models;

namespace CRIP.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<CRIPUser, UserSimplifyDto>();
            CreateMap<CRIPUser, UserDto>();
             //   .ForMember(
            //    dest => dest.IsRealName,
            //    opt => opt.MapFrom(src => src.IsRealName ? "已实名" : "尚未实名")
            //    )
              
        }
    }
}
