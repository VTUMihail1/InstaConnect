using AutoMapper;
using InstaConnect.Follows.Business.Models.Follows;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Follows.Data.Models.Filters;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFollows;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Follows.Business.Profiles.Follows;

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
