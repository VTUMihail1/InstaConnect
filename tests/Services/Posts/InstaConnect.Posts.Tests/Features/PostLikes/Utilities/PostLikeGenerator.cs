namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeGenerator
{
    extension(PostLike basePostLike)
    {
        public ICollection<PostLike> Generate(IEnumerable<Post> posts, IEnumerable<User> users)
        {
            return [.. posts
              .SelectMany(post =>
                  users.Select(user =>
                  {
                      var postLike = new PostLike(
                          new(post.Id, user.Id),
                          PostLikeDataFaker.GetCreatedAtUtc());

                      if(basePostLike.Id == postLike.Id)
                      {
                          return basePostLike;
                      }

                      user.AddPostLike(postLike);
                      post.AddPostLike(postLike);
                      postLike.AddUser(user);
                      postLike.AddPost(post);

                      return postLike;
                  }))];
        }
    }
}
