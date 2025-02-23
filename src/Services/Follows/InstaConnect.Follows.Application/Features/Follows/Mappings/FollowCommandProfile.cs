using AutoMapper;

namespace InstaConnect.Follows.Application.Features.Follows.Mappings;

internal class FollowCommandProfile : Profile
{
    public FollowCommandProfile()
    {
        CreateMap<Follow, FollowCommandViewModel>();
    }
}
