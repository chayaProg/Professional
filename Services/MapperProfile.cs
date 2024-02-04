using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Common.Entity;
using Repository.Entities;

namespace Services
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AreaDto, Area>().ReverseMap();
            CreateMap<CategoryDto,Category>().ReverseMap();
            CreateMap<ProfessionalDto,Professional>().ReverseMap();
            CreateMap<ResponseDto,Response>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }

    }
}
