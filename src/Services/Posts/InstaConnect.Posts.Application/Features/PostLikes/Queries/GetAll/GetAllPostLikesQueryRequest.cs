using InstaConnect.PostLikes.Domain.Features.PostLikes.Models;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;

public record GetAllPostLikesQueryRequest(
    PostLikeQueryFilter Filter,
    PostLikeQuerySorting Sorting,
    PostLikeQueryPagination Pagination)
    : IQueryRequest<GetAllPostLikesQueryResponse>;
