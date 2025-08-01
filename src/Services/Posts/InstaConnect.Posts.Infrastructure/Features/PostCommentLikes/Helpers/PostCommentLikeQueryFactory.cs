using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Helpers;

public class PostCommentLikeQueryFactory : IPostCommentLikeQueryFactory
{
    private readonly IPaginator _paginator;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IPostCommentLikeSortPropertyFactory _postCommentLikeSortPropertyFactory;

    public PostCommentLikeQueryFactory(
        IPaginator paginator,
        ISortOrderFactory sortOrderFactory,
        IPostCommentLikeSortPropertyFactory postCommentLikeSortPropertyFactory)
    {
        _paginator = paginator;
        _sortOrderFactory = sortOrderFactory;
        _postCommentLikeSortPropertyFactory = postCommentLikeSortPropertyFactory;
    }

    public GetAllPostCommentLikesQuerySpecification CreateGetAll(GetAllPostCommentLikesQuery query)
    {
        var sortOrder = _sortOrderFactory.Create(query.Sorting.Order);
        var sortProperty = _postCommentLikeSortPropertyFactory.Create(query.Sorting.Property);
        var offset = _paginator.GetOffset(query.Pagination.Page, query.Pagination.PageSize);
        var parameters = new GetAllPostCommentLikesQueryParameters(
            query.Filter.Id,
            query.Filter.CommentId,
            query.Filter.UserId,
            query.Filter.UserName,
            sortOrder.Order,
            sortProperty.Property,
            offset,
            query.Pagination.PageSize);

        var specification = new GetAllPostCommentLikesQuerySpecification(
            PostCommentLikeQuerySql.GetAll,
            parameters);

        return specification;
    }

    public GetAllPostCommentLikesTotalCountQuerySpecification CreateGetAllTotalCount(PostCommentLikeFilterQuery query)
    {
        var parameters = new GetAllPostCommentLikesTotalCountQueryParameters(
            query.Id,
            query.CommentId,
            query.UserId,
            query.UserName);

        var specification = new GetAllPostCommentLikesTotalCountQuerySpecification(
            PostCommentLikeQuerySql.GetAllTotalCount,
            parameters);

        return specification;
    }

    public GetPostCommentLikeByIdQuerySpecification CreateGetById(string id, string commentId, string commentLikeId)
    {
        var parameters = new GetPostCommentLikeByIdQueryParameters(id, commentId, commentLikeId);

        var result = new GetPostCommentLikeByIdQuerySpecification(
            PostCommentLikeQuerySql.GetById,
            parameters);

        return result;
    }

    public GetPostCommentLikeByIdAndUserIdQuerySpecification CreateGetByIdAndUserId(string id, string commentId, string userId)
    {
        var parameters = new GetPostCommentLikeByIdAndUserIdQueryParameters(id, commentId, userId);

        var result = new GetPostCommentLikeByIdAndUserIdQuerySpecification(
            PostCommentLikeQuerySql.GetById,
            parameters);

        return result;
    }
}
