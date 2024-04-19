using AutoMapper;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Api;

namespace UniversityBookShop.Application.Dto
{
    public class LoginByUserNameAndPasswordDto : IMapWith<LoginByUserNameAndPassword>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginByUserNameAndPasswordDto, LoginByUserNameAndPassword>();
        }
    }
}
