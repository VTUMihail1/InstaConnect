using InstaConnect.PostLikes.Application.Features.PostLikes.Models;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;

public record GetAllPostLikesQueryResponse(
    ICollection<PostLikeQueryResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
