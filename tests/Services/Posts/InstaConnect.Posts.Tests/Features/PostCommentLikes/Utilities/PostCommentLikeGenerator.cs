namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeGenerator
{
    public static ICollection<PostCommentLike> GenerateRange(this PostCommentLike template, IEnumerable<User> users)
    {
        return [.. users
            .Select(user =>
            {
                var postCommentLike = new PostCommentLike(
                    new(
                        template.Id.CommentId,
                        user.Id),
                    PostCommentLikeDataFaker.GetCreatedAtUtc());

                postCommentLike.AddUser(user);

                return postCommentLike;
            })];
    }
}
