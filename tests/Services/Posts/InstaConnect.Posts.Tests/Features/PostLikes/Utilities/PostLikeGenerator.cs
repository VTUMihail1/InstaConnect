namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
public static class PostLikeGenerator
{
    public static ICollection<PostLike> GeneratePostLikesRange(this IEnumerable<Post> posts, IEnumerable<User> users)
    {
        return [.. posts
              .SelectMany(post =>
                  users.Select(user =>
                  {
                      var postLike = new PostLike(
                          new(post.Id, user.Id),
                          PostLikeDataFaker.GetCreatedAtUtc());
              
                      postLike.AddUser(user);
                      postLike.AddPost(post);
              
                      return postLike;
                  }))];
    }
}
