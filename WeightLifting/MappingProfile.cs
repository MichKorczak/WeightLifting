﻿using AutoMapper;
using Data.DataTransferObject;
using Data.Models;
using System;

namespace WeightLifting
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contestant, ContestantForDisplay>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<ContestantForCreation, Contestant>()
                .ForMember(dest => dest.DateOfBirthday, opt => opt.MapFrom(
                    src => DateTime.Parse(src.DateOfBirthday)));
            CreateMap<ContestantForUpdate, Contestant>()
                .ForMember(dest => dest.DateOfBirthday, opt => opt.MapFrom(
                    src => DateTime.Parse(src.DateOfBirtch)));

            CreateMap<Attempt, AttemptForDisplay>();
            CreateMap<AttemptForCreation, Attempt>();
            CreateMap<AttemptForUpdate, Attempt>();

            CreateMap<Competition, CompetitionForDisplay>();
            CreateMap<CompetitionForCreation, Competition>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(
                    srt => DateTime.Parse(srt.Date)));
            CreateMap<CompetitionForUpdate, Competition>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(
                srt => DateTime.Parse(srt.Date)));

            CreateMap<ContestantCompetition, ContestantCompetitionForDisplay>();
            CreateMap<ContestantCompetitionForCreation, ContestantCompetition>();
            CreateMap<ContestantForUpdate, Contestant>();

        }

    }
}
