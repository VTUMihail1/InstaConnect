using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

using RabbitMQ.Client;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;
public static class PostGenerator
{
    public static ICollection<Post> GeneratePostsRange(this Post template, IEnumerable<User> users)
    {
        const int NumberOfIterationsPerUser = 5;

        return [.. users
            .SelectMany(user =>
                Enumerable.Range(default, NumberOfIterationsPerUser).Select(_ =>
                {
                    var post = new Post(
                        new(PostDataFaker.GetId()),
                        PostDataFaker.GetTitleWithPrefix(template.Title),
                        PostDataFaker.GetContent(),
                        user.Id,
                        PostDataFaker.GetCreatedAtUtc(),
                        PostDataFaker.GetUpdatedAtUtc());

                    var postLike = new PostLike(
                        new(post.Id, user.Id),
                        PostLikeDataFaker.GetCreatedAtUtc());

                    post.AddUser(user);
                    post.AddPostLike(postLike);

                    return post;
                }))];
    }
}
