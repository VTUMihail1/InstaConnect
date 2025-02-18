using InstaConnect.Shared.Application.Models.Filters;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public record GetAllPostsQuery(
    string UserId,
    string UserName,
    string Title,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<PostPaginationQueryViewModel>;
