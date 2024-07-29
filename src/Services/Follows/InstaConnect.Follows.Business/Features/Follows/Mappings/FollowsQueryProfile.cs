using AutoMapper;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFilteredFollows;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Follows.Data.Features.Follows.Models.Filters;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Follows.Business.Features.Follows.Mappings;

internal class FollowsQueryProfile : Profile
{
    public FollowsQueryProfile()
    {
        CreateMap<GetAllFilteredFollowsQuery, FollowFilteredCollectionReadQuery>();

        CreateMap<GetAllFollowsQuery, CollectionReadQuery>();

        CreateMap<Follow, FollowQueryViewModel>()
            .ConstructUsing(src => new(
                src.Id,
                src.FollowerId,
                src.Follower!.UserName,
                src.Follower.ProfileImage,
                src.FollowingId,
                src.Following!.UserName,
                src.Following.ProfileImage));

        CreateMap<PaginationList<Follow>, FollowPaginationQueryViewModel>();
    }
}
