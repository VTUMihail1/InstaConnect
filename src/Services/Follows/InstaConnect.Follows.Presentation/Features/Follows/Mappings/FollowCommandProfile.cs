using AutoMapper;

using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;

namespace InstaConnect.Follows.Presentation.Features.Follows.Mappings;

internal class FollowCommandProfile : Profile
{
    public FollowCommandProfile()
    {
        CreateMap<AddFollowRequest, AddFollowCommand>()
            .ConstructUsing(src => new(
                src.CurrentUserId,
                src.Body.FollowingId));

        CreateMap<DeleteFollowRequest, DeleteFollowCommand>()
            .ConstructUsing(src => new(
                src.Id,
                src.CurrentUserId));

        CreateMap<FollowCommandViewModel, FollowCommandResponse>();
    }
}
