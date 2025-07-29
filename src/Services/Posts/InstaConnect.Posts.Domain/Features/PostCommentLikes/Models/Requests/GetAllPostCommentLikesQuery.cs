namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

public record GetAllPostCommentLikesQuery(
    PostCommentLikeFilterQuery Filter,
    PostCommentLikeSortingQuery Sorting,
    PostCommentLikePaginationQuery Pagination);
