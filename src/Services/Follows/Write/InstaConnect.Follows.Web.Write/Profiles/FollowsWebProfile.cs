using AutoMapper;
using InstaConnect.Follows.Business.Commands.Follows.AddFollow;
using InstaConnect.Follows.Business.Commands.Follows.DeleteFollow;
using InstaConnect.Follows.Web.Models.Requests.Follows;

namespace InstaConnect.Follows.Web.Profiles;

public class FollowsWebProfile : Profile
{
    public FollowsWebProfile()
    {
        CreateMap<AddFollowRequest, AddFollowCommand>();

        CreateMap<DeleteFollowRequest, DeleteFollowCommand>();
    }
}
