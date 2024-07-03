using AutoMapper;
using InstaConnect.Follows.Write.Business.Commands.Follows.AddFollow;
using InstaConnect.Follows.Write.Business.Commands.Follows.DeleteFollow;
using InstaConnect.Follows.Write.Web.Models.Requests.Follows;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Follows.Write.Web.Profiles;

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
