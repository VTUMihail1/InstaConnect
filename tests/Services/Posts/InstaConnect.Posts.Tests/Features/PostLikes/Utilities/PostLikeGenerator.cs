namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
public static class PostLikeGenerator
{
    public static ICollection<PostLike> GenerateRange(this PostLike template, IEnumerable<User> users)
    {
        return [.. users
            .Select(user =>
            {
                var postLike = new PostLike(
                    new(
                        template.Id.Id,
                        user.Id),
                    PostLikeDataFaker.GetCreatedAtUtc());

                postLike.AddUser(user);

                return postLike;
            })];
    }
}
