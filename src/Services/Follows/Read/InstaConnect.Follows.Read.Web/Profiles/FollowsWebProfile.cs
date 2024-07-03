using AutoMapper;
using InstaConnect.Follows.Read.Business.Models;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFollows;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetFollowById;
using InstaConnect.Follows.Read.Web.Models.Requests.Follows;
using InstaConnect.Follows.Read.Web.Models.Responses;

namespace InstaConnect.Follows.Read.Web.Profiles;

public class FollowsWebProfile : Profile
{
    public FollowsWebProfile()
    {
        // Follows

        CreateMap<GetAllFollowsRequest, GetAllFollowsQuery>();

        CreateMap<GetAllFilteredFollowsRequest, GetAllFilteredFollowsQuery>();

        CreateMap<GetFollowByIdRequest, GetFollowByIdQuery>();

        CreateMap<FollowViewModel, FollowResponse>();
    }
}
