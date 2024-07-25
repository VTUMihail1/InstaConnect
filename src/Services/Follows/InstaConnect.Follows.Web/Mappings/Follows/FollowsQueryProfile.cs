using AutoMapper;
using InstaConnect.Follows.Business.Models.Follows;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFollows;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetFollowById;
using InstaConnect.Follows.Read.Web.Models.Requests.Follows;
using InstaConnect.Follows.Read.Web.Models.Responses;
using InstaConnect.Follows.Web.Models.Responses;
using InstaConnect.Messages.Business.Models;

namespace InstaConnect.Follows.Web.Profiles.Follows;

internal class FollowsQueryProfile : Profile
{
    public FollowsQueryProfile()
    {
        CreateMap<GetAllFollowsRequest, GetAllFollowsQuery>();

        CreateMap<GetAllFilteredFollowsRequest, GetAllFilteredFollowsQuery>();

        CreateMap<GetFollowByIdRequest, GetFollowByIdQuery>();

        CreateMap<FollowQueryViewModel, FollowQueryResponse>();

        CreateMap<FollowPaginationQueryViewModel, FollowPaginationQueryResponse>();
    }
}
