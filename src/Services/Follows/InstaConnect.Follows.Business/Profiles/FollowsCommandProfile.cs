using AutoMapper;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Follows.Read.Business.Models;
using InstaConnect.Follows.Write.Business.Commands.Follows.AddFollow;

namespace InstaConnect.Follows.Write.Business.Profiles;

public class FollowsCommandProfile : Profile
{
    public FollowsCommandProfile()
    {
        CreateMap<AddFollowCommand, Follow>()
            .ForMember(dest => dest.FollowerId, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<Follow, FollowCommandViewModel>();
    }
}
