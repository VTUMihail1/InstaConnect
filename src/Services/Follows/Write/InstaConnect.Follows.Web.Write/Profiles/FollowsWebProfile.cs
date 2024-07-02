using AutoMapper;
using InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
using InstaConnect.Follows.Business.Write.Commands.Follows.DeleteFollow;
using InstaConnect.Follows.Web.Write.Models.Requests.Follows;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Follows.Web.Write.Profiles;

public class FollowsWebProfile : Profile
{
    public FollowsWebProfile()
    {
        CreateMap<AddFollowRequest, AddFollowCommand>()
            .ForMember(dest => dest.FollowingId, opt => opt.MapFrom(src => src.AddFollowBindingModel.FollowingId));

        CreateMap<CurrentUserModel, AddFollowCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<DeleteFollowRequest, DeleteFollowCommand>();

        CreateMap<CurrentUserModel, DeleteFollowCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));
    }
}
