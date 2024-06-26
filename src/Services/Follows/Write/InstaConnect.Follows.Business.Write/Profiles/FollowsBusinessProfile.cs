using AutoMapper;
using InstaConnect.Follows.Business.Commands.Follows.AddFollow;
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

        CreateMap<CurrentUserDetails, Follow>()
            .ForMember(dest => dest.FollowerId, opt => opt.MapFrom(src => src.Id));

        CreateMap<GetUserByIdResponse, Follow>()
            .ForMember(dest => dest.FollowingId, opt => opt.MapFrom(src => src.Id));

        CreateMap<AddFollowCommand, Follow>();

        CreateMap<Follow, FollowCreatedEvent>();

        CreateMap<Follow, FollowDeletedEvent>();
    }
}
