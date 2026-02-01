using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeGenerator
{
    public static ICollection<PostCommentLike> GeneratePostCommentLikesRange(this ICollection<PostComment> postComments, IEnumerable<User> users)
    {
        return [.. postComments
              .SelectMany(postComment =>
                  users.Select(user =>
                  {
                      var postCommentLike = new PostCommentLike(
                          new(
                              postComment.Id,
                              user.Id),
                          PostCommentLikeDataFaker.GetCreatedAtUtc());

                      postCommentLike.AddUser(user);

                      return postCommentLike;
                  }))];
    }
}
