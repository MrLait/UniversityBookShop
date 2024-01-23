using AutoMapper;
using System;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Dto
{
    public class CurrencyCodeDto : IMapWith<CurrencyCode>
    {
        public int Id { get; set; }
        public string? Code { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CurrencyCode, CurrencyCodeDto>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(c => c.Code, opt => opt.MapFrom(src => src.Code));
        }
    }
}
