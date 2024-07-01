using AutoMapper;
using InstaConnect.Follows.Business.Commands.Follows.AddFollow;
using InstaConnect.Follows.Business.Write.Models;
using InstaConnect.Follows.Data.Write.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Follows;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Models.Users;

namespace InstaConnect.Follows.Business.Profiles;

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
