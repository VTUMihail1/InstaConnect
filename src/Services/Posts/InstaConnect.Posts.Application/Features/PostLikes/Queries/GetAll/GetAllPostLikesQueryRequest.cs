using InstaConnect.Common.Application.Models.Filters;

namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

public record GetAllPostLikesQueryRequest(
    string PostId,
    string UserId,
    string UserName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQueryRequest<PostLikePaginationQueryViewModel>;
