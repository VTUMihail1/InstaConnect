﻿using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllPostLikes;

public record GetAllPostLikesQuery(
    string UserId,
    string UserName,
    string PostId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<PostLikePaginationQueryViewModel>;
