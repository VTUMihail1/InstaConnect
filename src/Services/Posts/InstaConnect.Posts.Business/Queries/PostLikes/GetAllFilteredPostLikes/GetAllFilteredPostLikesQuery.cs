using InstaConnect.Posts.Business.Models.PostComment;
using InstaConnect.Posts.Business.Models.PostLike;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Posts.Business.Queries.PostLikes.GetAllFilteredPostLikes;

public record GetAllFilteredPostLikesQuery(
    string UserId,
    string UserName,
    string PostId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<PostLikePaginationQueryViewModel>;
