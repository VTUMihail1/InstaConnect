using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class PostBuilderFactory
{
    private readonly ObjectBuilderFactory<Post> _objectBuilderFactory = new();

    public PostBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var entityBuilder = new PostBuilder(objectBuilder, user);

        return entityBuilder;
    }
}
