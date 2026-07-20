using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myapi.DTOs.Certificate;
using myapi.Models;

namespace myapi.Mappings
{
    public class CertificateProfile : Profile
    {
        public CertificateProfile()
        {
            CreateMap<Certificate, CertificateDto>();
            CreateMap<CreateCertificateDto, Certificate>();
            CreateMap<UpdateCertificateDto, Certificate>();
        }
    }
}