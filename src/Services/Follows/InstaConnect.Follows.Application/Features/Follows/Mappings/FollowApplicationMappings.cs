using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

using Mapster;

namespace InstaConnect.Follows.Application.Features.Follows.Mappings;

public class FollowApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllFollowsByFollowerQueryRequest, GetAllFollowsByFollowerQuery>()
            .ConstructUsing(src => new(
                new(src.Filter.FollowerId, src.Filter.FollowingName),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<FollowCollection, GetAllFollowsByFollowingQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new FollowQueryResponse(
                                      new(
                                          p.FollowerId,
                                          p.Follower!.Name,
                                          p.Follower.ProfileImage),
                                      new(
                                          p.FollowingId,
                                          p.Following!.Name,
                                          p.Following.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetAllFollowsByFollowingQueryRequest, GetAllFollowsByFollowingQuery>()
            .ConstructUsing(src => new(
                new(src.Filter.FollowingId, src.Filter.FollowerName),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<FollowCollection, GetAllFollowsByFollowerQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new FollowQueryResponse(
                                      new(
                                          p.FollowerId,
                                          p.Follower!.Name,
                                          p.Follower.ProfileImage),
                                      new(
                                          p.FollowingId,
                                          p.Following!.Name,
                                          p.Following.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetFollowByIdQueryRequest, GetFollowByIdQuery>()
            .ConstructUsing(src => new(src.FollowerId, src.FollowingId));

        config.NewConfig<Follow, GetFollowByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(new(
                        src.FollowerId,
                        src.Follower!.Name,
                        src.Follower.ProfileImage),
                    new(
                        src.FollowingId,
                        src.Following!.Name,
                        src.Following.ProfileImage))));

        config.NewConfig<AddFollowCommandRequest, AddFollowCommand>()
            .ConstructUsing(src => new(src.FollowerId, src.FollowingId));

        config.NewConfig<Follow, AddFollowCommandResponse>()
            .ConstructUsing(src => new(src.FollowerId, src.FollowingId, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeleteFollowCommandRequest, DeleteFollowCommand>()
            .ConstructUsing(src => new(src.FollowerId, src.FollowingId));
    }
}
