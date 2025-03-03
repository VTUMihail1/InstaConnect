﻿namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;

public record PostLikePaginationQueryResponse(
    ICollection<PostLikeQueryResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
