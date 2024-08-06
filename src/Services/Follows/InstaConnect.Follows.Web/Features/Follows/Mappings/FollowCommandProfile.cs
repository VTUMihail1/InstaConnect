using AutoMapper;
using InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Business.Features.Follows.Commands.DeleteFollow;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Follows.Web.Features.Follows.Mappings;

internal class FollowCommandProfile : Profile
{
    public FollowCommandProfile()
    {
        CreateMap<(CurrentUserModel, AddFollowRequest), AddFollowCommand>()
            .ConstructUsing(src => new(
                src.Item1.Id,
                src.Item2.AddFollowBindingModel.FollowingId));

        CreateMap<(CurrentUserModel, DeleteFollowRequest), DeleteFollowCommand>()
            .ConstructUsing(src => new(
                src.Item2.Id,
                src.Item1.Id));

        CreateMap<FollowCommandViewModel, FollowCommandResponse>();
    }
}
