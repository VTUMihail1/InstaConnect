namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record GetAllPostLikesForUserQuery(
    PostLikesForUserFilterQuery Filter,
    PostLikesSortingQuery Sorting,
    PostLikesPaginationQuery Pagination,
    CurrentUserQuery CurrentUser)
    : ISortableQuery<PostLikesSortingQuery, PostLikesSortTerm>, IPaginatableQuery<PostLikesPaginationQuery>, ICurrentUserableQuery;
