using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollower;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollowing;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

using Mapster;

namespace InstaConnect.Follows.Presentation.Features.Follows.Mappings;

internal class FollowPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllFollowsByFollowerApiRequest, GetAllFollowsByFollowerQueryRequest>()
            .ConstructUsing(src => new(
                src.FollowerId,
                src.FollowingName,
                src.SortOrder,
                src.SortProperty,
                src.Page,
                src.PageSize));

        config.NewConfig<GetAllFollowsByFollowerQueryResponse, GetAllFollowsByFollowerApiResponse>()
            .ConstructUsing(src => new(src.Response.Adapt<FollowCollectionApiResponse>(config)));

        config.NewConfig<GetAllFollowsByFollowingApiRequest, GetAllFollowsByFollowingQueryRequest>()
            .ConstructUsing(src => new(
                src.FollowingId,
                src.FollowerName,
                src.SortOrder,
                src.SortProperty,
                src.Page,
                src.PageSize));

        config.NewConfig<GetAllFollowsByFollowingQueryResponse, GetAllFollowsByFollowingApiResponse>()
            .ConstructUsing(src => new(src.Response.Adapt<FollowCollectionApiResponse>(config)));

        config.NewConfig<GetFollowByIdApiRequest, GetFollowByIdQueryRequest>()
            .ConstructUsing(src => new(src.FollowerId,
                                       src.FollowingId));

        config.NewConfig<GetFollowByIdQueryResponse, GetFollowByIdApiResponse>()
            .ConstructUsing(src => new(src.Response.Adapt<FollowApiResponse>(config)));

        config.NewConfig<AddFollowApiRequest, AddFollowCommandRequest>()
            .ConstructUsing(src => new(src.FollowerId,
                                       src.FollowingId));

        config.NewConfig<AddFollowCommandResponse, AddFollowApiResponse>()
            .ConstructUsing(src => new(src.Response.Adapt<FollowIdApiResponse>(config)));

        config.NewConfig<DeleteFollowApiRequest, DeleteFollowCommandRequest>()
            .ConstructUsing(src => new(src.FollowerId,
                                       src.FollowingId));

        config.NewConfig<FollowIdCommandResponse, FollowIdApiResponse>()
            .ConstructUsing(src => new(
                src.FollowerId,
                src.FollowingId));

        config.NewConfig<FollowQueryResponse, FollowApiResponse>()
            .ConstructUsing(src => new(
                src.Follower.Adapt<UserApiResponse>(config),
                src.Following.Adapt<UserApiResponse>(config),
                src.CreatedAtUtc));

        config.NewConfig<FollowCollectionQueryResponse, FollowCollectionApiResponse>()
            .ConstructUsing(src => new(
                  src.Entities.Adapt<ICollection<FollowApiResponse>>(config),
                  src.Page,
                  src.PageSize,
                  src.TotalCount,
                  src.HasNextPage,
                  src.HasPreviousPage));
    }
}
