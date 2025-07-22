namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
public static class PostTestFactory
{
    public static Post Create(User user)
    {
        var post = new Post(
            PostDataFaker.GetId(),
            PostDataFaker.GetTitle(),
            PostDataFaker.GetContent(),
            user,
            PostDataFaker.GetCreatedAt(),
            PostDataFaker.GetUpdatedAt());

        return post;
    }
}
