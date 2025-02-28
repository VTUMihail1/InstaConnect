using InstaConnect.Common.Application.Models.Filters;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

public record GetAllPostCommentLikesQuery(
    string UserId,
    string UserName,
    string PostCommentId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<PostCommentLikePaginationQueryViewModel>;
