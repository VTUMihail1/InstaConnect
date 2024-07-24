using AutoMapper;
using InstaConnect.Follows.Read.Business.Models;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFollows;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetFollowById;
using InstaConnect.Follows.Read.Web.Models.Requests.Follows;
using InstaConnect.Follows.Read.Web.Models.Responses;
using InstaConnect.Follows.Write.Business.Commands.Follows.AddFollow;
using InstaConnect.Follows.Write.Business.Commands.Follows.DeleteFollow;
using InstaConnect.Follows.Write.Web.Models.Requests.Follows;
using InstaConnect.Follows.Write.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Follows.Read.Web.Profiles;

public class FollowsWebProfile : Profile
{
    public FollowsWebProfile()
    {
        CreateMap<GetAllFollowsRequest, GetAllFollowsQuery>();

        CreateMap<GetAllFilteredFollowsRequest, GetAllFilteredFollowsQuery>();

        CreateMap<GetFollowByIdRequest, GetFollowByIdQuery>();

        CreateMap<FollowQueryViewModel, FollowQueryResponse>();

        CreateMap<AddFollowRequest, AddFollowCommand>()
            .ForMember(dest => dest.FollowingId, opt => opt.MapFrom(src => src.AddFollowBindingModel.FollowingId));

        CreateMap<CurrentUserModel, AddFollowCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<DeleteFollowRequest, DeleteFollowCommand>();

        CreateMap<CurrentUserModel, DeleteFollowCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<FollowCommandViewModel, FollowCommandResponse>();
    }
}
