using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

public record FollowCollectionApiResponse(
    UserApiResponse? Follower,
    UserApiResponse? Following,
    ICollection<FollowApiResponse> Follows,
    int Page,
    int PageSize,
    long TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : ICollectionApiResponse;
