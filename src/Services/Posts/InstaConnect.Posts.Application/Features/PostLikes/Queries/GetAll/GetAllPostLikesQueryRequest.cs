using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

public record GetAllPostLikesQueryRequest(
    string Id,
    string UserName,
    CommonSortOrder SortOrder,
    PostLikeSortProperty SortProperty,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllPostLikesQueryResponse>;
