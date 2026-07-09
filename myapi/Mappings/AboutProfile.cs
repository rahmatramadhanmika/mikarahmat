using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myapi.DTOs.About;
using myapi.Models;

namespace myapi.Mappings
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<About, AboutDto>();
            CreateMap<CreateAboutDto, About>();
            CreateMap<UpdateAboutDto, About>();
        }
    }
}