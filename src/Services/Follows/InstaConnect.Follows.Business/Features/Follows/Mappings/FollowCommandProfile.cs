using AutoMapper;
using InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;

namespace InstaConnect.Follows.Business.Features.Follows.Mappings;

internal class FollowCommandProfile : Profile
{
    public FollowCommandProfile()
    {
        CreateMap<AddFollowCommand, Follow>()
            .ConstructUsing(src => new(src.CurrentUserId, src.FollowingId));

        CreateMap<Follow, FollowCommandViewModel>();
    }
}
