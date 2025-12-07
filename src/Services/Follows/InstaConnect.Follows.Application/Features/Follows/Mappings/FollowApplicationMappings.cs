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
                                       new(
                                           new(src.FollowerId),
                                           new(src.FollowingName)),
                                       new(
                                           src.SortOrder,
                                           src.SortProperty),
                                       new(
                                           src.Page,
                                           src.PageSize)));

        config.NewConfig<FollowCollection, GetAllFollowsByFollowingQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<FollowCollectionQueryResponse>(config)));

        config.NewConfig<GetAllFollowsByFollowingQueryRequest, GetAllFollowsByFollowingQuery>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.FollowingId),
                                           new(src.FollowerName)),
                                       new(
                                           src.SortOrder,
                                           src.SortProperty),
                                       new(
                                           src.Page,
                                           src.PageSize)));

        config.NewConfig<FollowCollection, GetAllFollowsByFollowerQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<FollowCollectionQueryResponse>(config)));

        config.NewConfig<GetFollowByIdQueryRequest, GetFollowByIdQuery>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.FollowerId),
                                           new(src.FollowingId))));

        config.NewConfig<Follow, GetFollowByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<FollowQueryResponse>(config)));

        config.NewConfig<AddFollowCommandRequest, AddFollowCommand>()
            .ConstructUsing(src => new(
                new(src.FollowerId),
                new(src.FollowingId)));

        config.NewConfig<Follow, AddFollowCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<FollowIdCommandResponse>(config)));

        config.NewConfig<DeleteFollowCommandRequest, DeleteFollowCommand>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.FollowerId),
                                           new(src.FollowingId))));

        config.NewConfig<FollowIdCommandResponse, FollowId>()
            .ConstructUsing(src => new(
                src.FollowerId.Adapt<UserId>(config),
                src.FollowingId.Adapt<UserId>(config)));

        config.NewConfig<FollowId, FollowIdCommandResponse>()
            .ConstructUsing(src => new(
                src.FollowerId.Id,
                src.FollowingId.Id));

        config.NewConfig<Follow, FollowQueryResponse>()
            .ConstructUsing(src => new(
                src.Follower.Adapt<UserQueryResponse>(config),
                src.Following.Adapt<UserQueryResponse>(config),
                src.CreatedAtUtc));

        config.NewConfig<FollowCollection, FollowCollectionQueryResponse>()
            .ConstructUsing(src => new(
                  src.Entities.Adapt<ICollection<FollowQueryResponse>>(),
                  src.Page,
                  src.PageSize,
                  src.TotalCount,
                  src.HasNextPage,
                  src.HasPreviousPage));
    }
}
