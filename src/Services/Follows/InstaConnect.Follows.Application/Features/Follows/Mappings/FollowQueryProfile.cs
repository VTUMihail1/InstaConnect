using AutoMapper;

using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;

namespace InstaConnect.Follows.Application.Features.Follows.Mappings;

internal class FollowQueryProfile : Profile
{
    public FollowQueryProfile()
    {
        CreateMap<GetAllFollowsQuery, FollowCollectionReadQuery>();

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
