using AutoMapper;
using Domain.Entities;
using Application.DTOs.User;
using Application.DTOs.Group;
using Application.DTOs.Location;
using Application.DTOs.TeamContestResult;
using Application.DTOs.TeamQuestionResult;
using Application.DTOs.UserContestResult;
using Application.DTOs.UserQuestionResult;

namespace Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserEntity, UserRequestDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
                if (srcMember is int and 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
            
            CreateMap<UserEntity, UserResponseDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
                if (srcMember is int and 0)
                {
                    return false;
                }
                return srcMember != null;
            }));

            
            CreateMap<GroupEntity, GroupDto>().ReverseMap().ForAllMembers(opts=> opts.Condition((src, dest, srcMember) => {
                if (srcMember is int and 0)
                {
                    return false;
                }
                return srcMember != null;
            })); 
            
            CreateMap<GroupEntity, GroupResponseDto>().ReverseMap().ForAllMembers(opts=> opts.Condition((src, dest, srcMember) => {
                if (srcMember is int and 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
            
            CreateMap<LocationEntity, LocationDto>().ReverseMap().ForAllMembers(opts=> opts.Condition((src, dest, srcMember) => {
                if (srcMember is int and 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
            
            CreateMap<LocationEntity, LocationResponseDto>().ReverseMap().ForAllMembers(opts=> opts.Condition((src, dest, srcMember) => {
                if (srcMember is int and 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
            
            CreateMap<UserQuestionsResultResponseDto, UserQuestionResultEntity>().ReverseMap().ForAllMembers(opts=> opts.Condition((src, dest, srcMember) => {
                if (srcMember is int and 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
            
            CreateMap<TeamQuestionResultResponseDto, TeamQuestionResultEntity>().ReverseMap().ForAllMembers(opts=> opts.Condition((src, dest, srcMember) => {
                if (srcMember is int and 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
            
            CreateMap<TeamContestResultEntity, TeamContestResultResponseDto>().ReverseMap().ForAllMembers(opts=> opts.Condition((src, dest, srcMember) => {
                if (srcMember is int and 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
            
            CreateMap<UserContestResultEntity, UserContestResultResponseDto>().ReverseMap().ForAllMembers(opts=> opts.Condition((src, dest, srcMember) => {
                if (srcMember is int and 0)
                {
                    return false;
                }
                return srcMember != null;
            }));

        }

    }
}