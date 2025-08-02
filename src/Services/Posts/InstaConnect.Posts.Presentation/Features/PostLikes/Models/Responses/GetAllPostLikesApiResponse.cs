using InstaConnect.PostLikes.Application.Features.PostLikes.Models;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;

public record GetAllPostLikesApiResponse(
    ICollection<PostLikeApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
