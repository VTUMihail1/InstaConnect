namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record GetAllPostCommentsForUserQuery(
    PostCommentsForUserFilterQuery Filter,
    PostCommentsSortingQuery Sorting,
    PostCommentsPaginationQuery Pagination,
    CurrentUserQuery CurrentUser)
    : ISortableQuery<PostCommentsSortingQuery, PostCommentsSortTerm>, IPaginatableQuery<PostCommentsPaginationQuery>, ICurrentUserableQuery;
