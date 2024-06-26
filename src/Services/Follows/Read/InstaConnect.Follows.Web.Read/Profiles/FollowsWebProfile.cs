using AutoMapper;
using InstaConnect.Follows.Business.Read.Models;
using InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFollows;
using InstaConnect.Follows.Business.Read.Queries.Follows.GetFollowById;
using InstaConnect.Follows.Web.Read.Models.Requests.Follows;
using InstaConnect.Follows.Web.Read.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;

namespace InstaConnect.Follows.Web.Read.Profiles;

public class FollowsWebProfile : Profile
{
    public FollowsWebProfile()
    {
        // Follows

        CreateMap<CollectionRequest, GetAllFollowsQuery>();

        CreateMap<GetFollowCollectionRequest, GetAllFilteredFollowsQuery>();

        CreateMap<GetFollowByIdRequest, GetFollowByIdQuery>();

        CreateMap<FollowViewModel, FollowResponse>();
    }
}
