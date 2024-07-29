using AutoMapper;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFilteredFollows;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Web.Features.Follows.Mappings;

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
