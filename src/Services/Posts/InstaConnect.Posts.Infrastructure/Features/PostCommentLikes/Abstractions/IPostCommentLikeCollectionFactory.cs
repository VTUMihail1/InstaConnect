namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;
internal interface IPostCommentLikeCollectionFactory
{
    PostCommentLikeCollection Create(ICollection<PostCommentLike> entities, int totalCount, PostCommentLikePaginationQuery pagination);
}
