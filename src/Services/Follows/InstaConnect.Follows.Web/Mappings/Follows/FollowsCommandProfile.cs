using AutoMapper;
using InstaConnect.Follows.Business.Models.Follows;
using InstaConnect.Follows.Write.Business.Commands.Follows.AddFollow;
using InstaConnect.Follows.Write.Business.Commands.Follows.DeleteFollow;
using InstaConnect.Follows.Write.Web.Models.Requests.Follows;
using InstaConnect.Follows.Write.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Follows.Web.Profiles.Follows;

internal class FollowsCommandProfile : Profile
{
    public FollowsCommandProfile()
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
