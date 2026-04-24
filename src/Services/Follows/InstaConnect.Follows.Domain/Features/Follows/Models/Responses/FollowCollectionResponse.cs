using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

public record FollowCollectionResponse(
    UserResponse? Follower,
    UserResponse? Following,
    ICollection<FollowResponse> Follows,
    int Page,
    int PageSize,
    long TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : IEntityCollectionResponse;
