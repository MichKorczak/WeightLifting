using AutoMapper;
using Data.DataTransferObject;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeightLifting
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contestant, ContestantForDisplay>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<ContestandForCreation, Contestant>()
                .ForMember(dest => dest.DateOfBirthday, opt => opt.MapFrom(
                    src => DateTime.Parse(src.DateOfBirthday)));
        }

    }
}
