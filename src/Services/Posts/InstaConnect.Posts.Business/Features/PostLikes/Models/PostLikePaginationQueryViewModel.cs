﻿using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Posts.Business.Features.PostLikes.Models;

public record PostLikePaginationQueryViewModel(
    ICollection<PostLikeQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryViewModel<PostLikeQueryViewModel>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);