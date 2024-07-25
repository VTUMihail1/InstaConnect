using AutoMapper;
using InstaConnect.Follows.Business.Models.Follows;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Follows.Write.Business.Commands.Follows.AddFollow;

namespace InstaConnect.Follows.Business.Profiles.Follows;

internal class FollowsCommandProfile : Profile
{
    public FollowsCommandProfile()
    {
        CreateMap<AddFollowCommand, Follow>()
            .ConstructUsing(src => new(src.CurrentUserId, src.FollowingId));

        CreateMap<Follow, FollowCommandViewModel>();
    }
}
