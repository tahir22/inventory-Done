using AutoMapper;
using Stocky.Data.Entities;
using Stocky.Data.Models;
using System.Linq;

namespace Stocky
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RoleListModel, ApplicationRole>().ReverseMap();
            CreateMap<UserModel, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, UserInfoModel>().ReverseMap();
            CreateMap<UserListModel, ApplicationUser>().ReverseMap();
            CreateMap<UserCreateModel, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationClaim, PermissionListModel>().ReverseMap();
        }
    }
}
  