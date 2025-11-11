namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class DeletePostCommandRequestBuilderFactory
{
    public DeletePostCommandRequestBuilder Create(Post post)
    {
        return new(post);
    }
}
