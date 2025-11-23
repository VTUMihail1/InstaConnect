using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollower;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollowing;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Follows.Presentation.Features.Follows.Mappings;

internal class FollowPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllFollowsByFollowerApiRequest, GetAllFollowsByFollowerQueryRequest>()
            .ConstructUsing(src => new(
                new(
                    new(src.FollowerId),
                    new(src.FollowingName)),
                new(src.SortOrder, src.SortProperty),
                new(src.Page, src.PageSize)));

        config.NewConfig<GetAllFollowsByFollowerQueryResponse, GetAllFollowsByFollowerApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Adapt<ICollection<FollowApiResponse>>(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetAllFollowsByFollowingApiRequest, GetAllFollowsByFollowingQueryRequest>()
            .ConstructUsing(src => new(
                new(
                    new(src.FollowingId),
                    new(src.FollowerName)),
                new(src.SortOrder, src.SortProperty),
                new(src.Page, src.PageSize)));

        config.NewConfig<GetAllFollowsByFollowingQueryResponse, GetAllFollowsByFollowingApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Adapt<ICollection<FollowApiResponse>>(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetFollowByIdApiRequest, GetFollowByIdQueryRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.FollowerId),
                                           new(src.FollowingId))));

        config.NewConfig<GetFollowByIdQueryResponse, GetFollowByIdApiResponse>()
            .ConstructUsing(src => new(src.Data.Adapt<FollowApiResponse>()));

        config.NewConfig<AddFollowApiRequest, AddFollowCommandRequest>()
            .ConstructUsing(src => new(
                                       new(src.FollowerId),
                                       new(src.FollowingId)));

        config.NewConfig<AddFollowCommandResponse, AddFollowApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<FollowIdApiPayload>()));

        config.NewConfig<DeleteFollowApiRequest, DeleteFollowCommandRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.FollowerId),
                                           new(src.FollowingId))));

        config.NewConfig<FollowIdPayload, FollowIdApiPayload>()
            .ConstructUsing(src => new(
                src.FollowerId.Adapt<UserIdApiPayload>(),
                src.FollowingId.Adapt<UserIdApiPayload>()));

        config.NewConfig<FollowIdApiPayload, FollowIdPayload>()
            .ConstructUsing(src => new(
                src.FollowerId.Adapt<UserIdPayload>(),
                src.FollowingId.Adapt<UserIdPayload>()));

        config.NewConfig<FollowQueryResponse, FollowApiResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<FollowIdApiPayload>(),
                src.Follower.Adapt<UserApiResponse>(),
                src.Following.Adapt<UserApiResponse>(),
                src.CreatedAtUtc));
    }
}
