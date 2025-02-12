using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Models.Filters;
using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

public record GetAllPostCommentsQuery(
    string UserId,
    string UserName,
    string PostId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<PostCommentPaginationQueryViewModel>;
