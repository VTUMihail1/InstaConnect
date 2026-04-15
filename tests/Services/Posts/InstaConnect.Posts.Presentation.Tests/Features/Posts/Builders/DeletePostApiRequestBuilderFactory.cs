namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class DeletePostApiRequestBuilderFactory
{
    public DeletePostApiRequestBuilder Create(Post post)
    {
        return new(post);
    }
}
