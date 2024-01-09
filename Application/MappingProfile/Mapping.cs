using Application.DTOs.Contest;
using Application.DTOs.ContestGroup;
using AutoMapper;
using Domain.Entities;
using Application.DTOs.User;
using Application.DTOs.Group;
using Application.DTOs.Location;
using Application.DTOs.Question;
using Application.DTOs.TeamContestResult;
using Application.DTOs.TeamQuestionResult;
using Application.DTOs.UserContestResult;
using Application.DTOs.UserQuestionResult;
using Application.DTOs.UserType;
using AutoMapper.Execution;
using Microsoft.AspNetCore.SignalR;

namespace Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserRequestDto>().ReverseMap().ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int and 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));

            CreateMap<UserEntity, UserResponseDto>().ReverseMap().ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int and 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));


            CreateMap<GroupEntity, GroupDto>().ReverseMap().ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int and 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));

            CreateMap<GroupEntity, GroupResponseDto>().ReverseMap().ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int and 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));

            CreateMap<LocationEntity, LocationDto>().ReverseMap().ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int and 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));

            CreateMap<LocationEntity, LocationResponseDto>().ReverseMap().ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int and 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));

            CreateMap<UserQuestionsResultResponseDto, UserQuestionResultEntity>().ReverseMap().ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int and 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));

            CreateMap<TeamQuestionResultResponseDto, TeamQuestionResultEntity>().ReverseMap().ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int and 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));

            CreateMap<TeamContestResultEntity, TeamContestResultResponseDto>().ReverseMap().ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int and 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));

            CreateMap<UserContestResultEntity, UserContestResultResponseDto>().ReverseMap().ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int and 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));

            CreateMap<UserTypeEntity, UserTypeDto>().ReverseMap().ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int and 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));

            CreateMap<UserTypeEntity, UserTypeResponseDto>().ReverseMap().ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int and 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));

            CreateMap<ContestGroupEntity, ContestGroupWithoutContestDto>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group));
                
            // map ContestEntity for members [ContestGlobalId, ContestUrl, Name, Type, DurationSeconds, StartTimeSeconds, RelativeTimeSeconds, PreparedBy, WebsiteUrl, Description, Difficulty, Kind, Season, Status, ContestGroups]
            CreateMap<ContestEntity, ContestResponseDto>()
                .ReverseMap()
                .ForMember(dest => dest.ContestGlobalId, opt => opt.MapFrom(src => src.ContestGlobalId))
                .ForMember(dest => dest.ContestUrl, opt => opt.MapFrom(src => src.ContestUrl))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.DurationSeconds, opt => opt.MapFrom(src => src.DurationSeconds))
                .ForMember(dest => dest.StartTimeSeconds, opt => opt.MapFrom(src => src.StartTimeSeconds))
                .ForMember(dest => dest.RelativeTimeSeconds, opt => opt.MapFrom(src => src.RelativeTimeSeconds))
                .ForMember(dest => dest.PreparedBy, opt => opt.MapFrom(src => src.PreparedBy))
                .ForMember(dest => dest.WebsiteUrl, opt => opt.MapFrom(src => src.WebsiteUrl))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.Difficulty))
                .ForMember(dest => dest.Kind, opt => opt.MapFrom(src => src.Kind))
                .ForMember(dest => dest.Season, opt => opt.MapFrom(src => src.Season))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.ContestGroups, opt => opt.MapFrom(src => src.ContestGroups))
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions))
                .ForMember(dest => dest.UserContestResults, opt => opt.MapFrom(src => src.UserContestResults))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt));

            CreateMap<QuestionEntity, QuestionResponseDto>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is int && (int)srcMember == 0)
                    {
                        return false;
                    }

                    return srcMember != null;
                }));

            CreateMap<UserEntity, FilteredUserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.CodeforcesHandle, opt => opt.MapFrom(src => src.CodeforcesHandle))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.NumberOfProblemsTaken, opt => opt.MapFrom(src => src.UserQuestionResults.Count))
                .ForMember(dest => dest.NumberOfProblemsSolved,
                    opt => opt.MapFrom(src => src.UserQuestionResults.Count(x => x.Points != 0)))
                .ForMember(dest => dest.ContestConversionRate,
                    opt => opt.MapFrom((src, dest, member, context) => dest.NumberOfProblemsTaken != 0
                        ? (double)dest.NumberOfProblemsSolved / dest.NumberOfProblemsTaken
                        : 0))
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group))
                // map createdat date
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt));
            
            CreateMap<GroupEntity, GroupRankingDto>()
                .ForMember(dest => 
                    dest.Id, opt => 
                    opt.MapFrom(src => src.Id))
                .ForMember(dest => 
                    dest.Name, opt => 
                    opt.MapFrom(src => src.Name))
                .ForMember(dest => 
                    dest.Abbreviation, opt => 
                    opt.MapFrom(src => src.Abbreviation))
                .ForMember(dest => 
                    dest.Generation, opt => 
                    opt.MapFrom(src => src.Generation))
                .ForMember(dest => 
                    dest.Location, opt => 
                    opt.MapFrom(src => src.Location))
                .ForMember(dest => 
                    dest.Members, opt => 
                    opt.MapFrom(src => src.Members))
                .ForMember(dest => 
                    dest.NumberOfProblemsTaken, opt => 
                    opt.MapFrom(src => src.Members.Count > 0 ? src.Members[0].NumberOfProblemsTaken : 0))
                .ForMember(dest => 
                        dest.AverageNumberOfProblemsSolved,
                    opt => 
                        opt.MapFrom(src => src.Members.Count == 0 ? 0 : src.Members.Sum(m => m.NumberOfProblemsSolved) / src.Members.Count))
                .ForMember(dest => 
                        dest.ContestConversionRate,
                    opt => 
                        opt.MapFrom((src, dest, member, context) => 
                            dest.NumberOfProblemsTaken != 0
                        ? (double)dest.NumberOfProblemsSolved / dest.NumberOfProblemsTaken
                        : 0))
                .ForMember(dest => 
                    dest.CreatedAt, opt => 
                    opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => 
                    dest.ModifiedAt, opt => 
                    opt.MapFrom(src => src.ModifiedAt));
            
        }
    }
}