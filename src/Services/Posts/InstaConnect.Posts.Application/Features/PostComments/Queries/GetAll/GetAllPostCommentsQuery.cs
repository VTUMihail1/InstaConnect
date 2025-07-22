using InstaConnect.Common.Application.Models.Filters;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

public record GetAllPostCommentsQuery(
    string PostId,
    string UserId,
    string UserName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQueryRequest<PostCommentPaginationQueryViewModel>;
