using AutoMapper;
using InstaConnect.Follows.Write.Business.Commands.Follows.AddFollow;
using InstaConnect.Follows.Write.Business.Models;
using InstaConnect.Follows.Write.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Follows;
using InstaConnect.Shared.Business.Contracts.Users;

namespace InstaConnect.Follows.Write.Business.Profiles;

public class FollowsBusinessProfile : Profile
{
    public FollowsBusinessProfile()
    {
        CreateMap<AddFollowCommand, GetUserByIdRequest>();

        CreateMap<AddFollowCommand, FollowGetUserByIdModel>()
            .ForMember(dest => dest.GetUserByFollowerIdRequest.Id, opt => opt.MapFrom(src => src.CurrentUserId))
            .ForMember(dest => dest.GetUserByFollowingIdRequest.Id, opt => opt.MapFrom(src => src.FollowingId));

        CreateMap<AddFollowCommand, Follow>()
            .ForMember(dest => dest.FollowerId, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<Follow, FollowCreatedEvent>();

        CreateMap<Follow, FollowDeletedEvent>();
    }
}
