using AutoMapper;
using InstaConnect.Follows.Application.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Application.Features.Follows.Commands.DeleteFollow;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Presentation.Features.Follows.Mappings;

internal class FollowCommandProfile : Profile
{
    public FollowCommandProfile()
    {
        CreateMap<AddFollowRequest, AddFollowCommand>()
            .ConstructUsing(src => new(
                src.CurrentUserId,
                src.AddFollowBindingModel.FollowingId));

        CreateMap<DeleteFollowRequest, DeleteFollowCommand>()
            .ConstructUsing(src => new(
                src.Id,
                src.CurrentUserId));

        CreateMap<FollowCommandViewModel, FollowCommandResponse>();
    }
}
