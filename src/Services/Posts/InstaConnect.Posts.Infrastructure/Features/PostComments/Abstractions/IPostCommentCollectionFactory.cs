namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
internal interface IPostCommentCollectionFactory
{
    PostCommentCollection Create(ICollection<PostComment> postComments, int totalCount, PostCommentPaginationQuery pagination);
}
