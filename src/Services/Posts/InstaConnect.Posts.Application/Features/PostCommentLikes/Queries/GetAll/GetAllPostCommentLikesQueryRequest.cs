using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models;

namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;

public record GetAllPostCommentLikesQueryRequest(
    PostCommentLikeQueryFilter Filter,
    PostCommentLikeQuerySorting Sorting,
    PostCommentLikeQueryPagination Pagination)
    : IQueryRequest<GetAllPostCommentLikesQueryResponse>;
