using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myapi.DTOs.Achievement;
using myapi.Models;

namespace myapi.Mappings
{
    public class AchievementProfile : Profile
    {
        public AchievementProfile()
        {
            CreateMap<Achievement, AchievementDto>()
            .ForMember(dest => dest.AchievementMedias,
            opt => opt.MapFrom(src => src.AchievementMedias));

            CreateMap<CreateAchievementDto, Achievement>()
            .ForMember(dest => dest.AchievementMedias,
            opt => opt.MapFrom(src => src.AchievementMedias));

            CreateMap<UpdateAchievementDto, Achievement>()
            .ForMember(dest => dest.AchievementMedias,
            opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt,
            opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt,
            opt => opt.Ignore());

            CreateMap<AchievementMedia, AchievementMediaDto>();
            CreateMap<CreateAchievementMediaDto, AchievementMedia>();
            CreateMap<UpdateAchievementMediaDto, AchievementMedia>();
        }
    }
}