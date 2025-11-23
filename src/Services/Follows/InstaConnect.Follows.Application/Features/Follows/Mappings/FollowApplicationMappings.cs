using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollower;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollowing;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

using Mapster;

namespace InstaConnect.Follows.Application.Features.Follows.Mappings;

public class FollowApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllFollowsByFollowerQueryRequest, GetAllFollowsByFollowerQuery>()
            .ConstructUsing(src => new(
                src.Filter.Adapt<FollowByFollowerFilterQuery>(),
                src.Sorting.Adapt<FollowByFollowerSortingQuery>(),
                src.Pagination.Adapt<FollowPaginationQuery>()));

        config.NewConfig<FollowCollection, GetAllFollowsByFollowingQueryResponse>()
            .ConstructUsing(src => new(
                  src.Data.Adapt<ICollection<FollowQueryResponse>>(),
                  src.Page,
                  src.PageSize,
                  src.TotalCount,
                  src.HasNextPage,
                  src.HasPreviousPage));

        config.NewConfig<GetAllFollowsByFollowingQueryRequest, GetAllFollowsByFollowingQuery>()
            .ConstructUsing(src => new(
                src.Filter.Adapt<FollowByFollowingFilterQuery>(),
                src.Sorting.Adapt<FollowByFollowingSortingQuery>(),
                src.Pagination.Adapt<FollowPaginationQuery>()));

        config.NewConfig<FollowCollection, GetAllFollowsByFollowerQueryResponse>()
            .ConstructUsing(src => new(
                  src.Data.Adapt<ICollection<FollowQueryResponse>>(),
                  src.Page,
                  src.PageSize,
                  src.TotalCount,
                  src.HasNextPage,
                  src.HasPreviousPage));

        config.NewConfig<GetFollowByIdQueryRequest, GetFollowByIdQuery>()
            .ConstructUsing(src => new(src.Id.Adapt<FollowId>()));

        config.NewConfig<Follow, GetFollowByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<FollowQueryResponse>()));

        config.NewConfig<AddFollowCommandRequest, AddFollowCommand>()
            .ConstructUsing(src => new(
                src.FollowerId.Adapt<UserId>(),
                src.FollowingId.Adapt<UserId>()));

        config.NewConfig<Follow, AddFollowCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<FollowIdPayload>()));

        config.NewConfig<DeleteFollowCommandRequest, DeleteFollowCommand>()
            .ConstructUsing(src => new(src.Id.Adapt<FollowId>()));

        config.NewConfig<FollowIdPayload, FollowId>()
            .ConstructUsing(src => new(
                src.FollowerId.Adapt<UserId>(),
                src.FollowingId.Adapt<UserId>()));

        config.NewConfig<FollowId, FollowIdPayload>()
            .ConstructUsing(src => new(
                src.FollowerId.Adapt<UserIdPayload>(),
                src.FollowingId.Adapt<UserIdPayload>()));

        config.NewConfig<Follow, FollowQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<FollowIdPayload>(),
                src.Follower.Adapt<UserQueryResponse>(),
                src.Following.Adapt<UserQueryResponse>(),
                src.CreatedAtUtc));

        config.NewConfig<FollowByFollowerFilterQueryRequest, FollowByFollowerFilterQuery>()
            .ConstructUsing(src => new(
                src.FollowerId.Adapt<UserId>(),
                src.FollowingName.Adapt<Name>()));

        config.NewConfig<FollowByFollowingFilterQueryRequest, FollowByFollowingFilterQuery>()
            .ConstructUsing(src => new(
                src.FollowingId.Adapt<UserId>(),
                src.FollowerName.Adapt<Name>()));

        config.NewConfig<FollowByFollowerSortingQueryRequest, FollowByFollowerSortingQuery>()
            .ConstructUsing(src => new(
                src.Order,
                src.Property));

        config.NewConfig<FollowByFollowingSortingQueryRequest, FollowByFollowingSortingQuery>()
            .ConstructUsing(src => new(
                src.Order,
                src.Property));

        config.NewConfig<FollowPaginationQueryRequest, FollowPaginationQuery>()
            .ConstructUsing(src => new(
                src.Page,
                src.PageSize));
    }
}
