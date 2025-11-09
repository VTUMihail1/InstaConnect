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
                new(src.Filter.FollowerId, src.Filter.FollowingName),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<GetAllFollowsByFollowerQueryResponse, GetAllFollowsByFollowerApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new FollowApiResponse(
                                      new(
                                          p.Follower.Id,
                                          p.Follower.Name,
                                          p.Follower.ProfileImage),
                                      new(
                                          p.Following.Id,
                                          p.Following.Name,
                                          p.Following.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetAllFollowsByFollowingApiRequest, GetAllFollowsByFollowingQueryRequest>()
            .ConstructUsing(src => new(
                new(src.Filter.FollowingId, src.Filter.FollowerName),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<GetAllFollowsByFollowingQueryResponse, GetAllFollowsByFollowingApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new FollowApiResponse(
                                      new(
                                          p.Follower.Id,
                                          p.Follower.Name,
                                          p.Follower.ProfileImage),
                                      new(
                                          p.Following.Id,
                                          p.Following.Name,
                                          p.Following.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetFollowByIdApiRequest, GetFollowByIdQueryRequest>()
            .ConstructUsing(src => new(src.FollowerId, src.FollowingId));

        config.NewConfig<GetFollowByIdQueryResponse, GetFollowByIdApiResponse>()
            .ConstructUsing(src => new(
                new(new(
                        src.Data.Follower.Id,
                        src.Data.Follower.Name,
                        src.Data.Follower.ProfileImage),
                    new(
                        src.Data.Following.Id,
                        src.Data.Following.Name,
                        src.Data.Following.ProfileImage))));

        config.NewConfig<AddFollowApiRequest, AddFollowCommandRequest>()
            .ConstructUsing(src => new(src.FollowerId, src.FollowingId));

        config.NewConfig<AddFollowCommandResponse, AddFollowApiResponse>()
            .ConstructUsing(src => new(src.FollowerId, src.FollowingId, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeleteFollowApiRequest, DeleteFollowCommandRequest>()
            .ConstructUsing(src => new(src.FollowerId, src.FollowingId));
    }
}
