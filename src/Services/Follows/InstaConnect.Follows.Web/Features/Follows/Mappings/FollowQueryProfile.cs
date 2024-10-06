using AutoMapper;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Web.Features.Follows.Mappings;

internal class FollowQueryProfile : Profile
{
    public FollowQueryProfile()
    {
        CreateMap<GetAllFollowsRequest, GetAllFollowsQuery>();

        CreateMap<GetFollowByIdRequest, GetFollowByIdQuery>();

        CreateMap<FollowQueryViewModel, FollowQueryResponse>();

        CreateMap<FollowPaginationQueryViewModel, FollowPaginationQueryResponse>();
    }
}
