using AutoMapper;

using InstaConnect.Follows.Application.Features.Follows.Commands.Add;

namespace InstaConnect.Follows.Application.Features.Follows.Mappings;

internal class FollowCommandProfile : Profile
{
    public FollowCommandProfile()
    {
        CreateMap<AddFollowCommand, Follow>()
            .ConstructUsing(src => new(src.CurrentUserId, src.FollowingId));

        CreateMap<Follow, FollowCommandViewModel>();
    }
}
