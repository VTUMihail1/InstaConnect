using InstaConnect.Posts.Business.Models.PostCommentLike;
using InstaConnect.Posts.Business.Models.PostLike;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Posts.Business.Queries.PostLikes.GetAllPostLikes;

public record GetAllPostLikesQuery(
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<PostLikePaginationQueryViewModel>;
