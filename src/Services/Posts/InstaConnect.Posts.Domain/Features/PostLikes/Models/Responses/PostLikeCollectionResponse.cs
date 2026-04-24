using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;

public record PostLikeCollectionResponse(
        PostResponse? Post,
        UserResponse? User,
        ICollection<PostLikeResponse> PostLikes,
        int Page,
        int PageSize,
        long TotalCount,
        bool HasNextPage,
        bool HasPreviousPage) : IEntityCollectionResponse;
