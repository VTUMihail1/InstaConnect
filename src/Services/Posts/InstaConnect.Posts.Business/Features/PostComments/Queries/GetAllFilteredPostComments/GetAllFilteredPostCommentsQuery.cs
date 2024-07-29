using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllFilteredPostComments;

public record GetAllFilteredPostCommentsQuery(
    string UserId,
    string UserName,
    string PostId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<PostCommentPaginationQueryViewModel>;
