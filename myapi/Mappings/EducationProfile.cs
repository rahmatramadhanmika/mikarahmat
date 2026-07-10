using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myapi.DTOs.Education;
using myapi.Models;

namespace myapi.Mappings
{
    public class EducationProfile : Profile
    {
        public EducationProfile()
        {
            CreateMap<Education, EducationDto>();
            CreateMap<CreateEducationDto, Education>();
            CreateMap<UpdateEducationDto, Education>();
        }
    }
}