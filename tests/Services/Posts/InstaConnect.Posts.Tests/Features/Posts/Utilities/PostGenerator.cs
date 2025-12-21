using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;
public static class PostGenerator
{
    public static ICollection<Post> GenerateRange(this Post template, IEnumerable<User> users)
    {
        return [.. users
            .Select(user =>
            {
                var post = new Post(new(PostDataFaker.GetId()),
                                    PostDataFaker.GetTitleWithPrefix(template.Title),
                                    PostDataFaker.GetContent(),
                                    user.Id,
                                    PostDataFaker.GetCreatedAtUtc(),
                                    PostDataFaker.GetUpdatedAtUtc());

                post.AddUser(user);

                return post;
            })];
    }
}
