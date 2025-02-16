using AutoMapper;

using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Presentation.Features.Follows.Mappings;

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
