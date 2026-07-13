using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myapi.DTOs.Experience;
using myapi.Models;

namespace myapi.Mappings
{
    public class ExperienceProfile : Profile
    {
        public ExperienceProfile()
        {
            CreateMap<Experience, ExperienceDto>();
            CreateMap<CreateExperienceDto, Experience>();
            CreateMap<UpdateExperienceDto, Experience>();
        }
    }
}