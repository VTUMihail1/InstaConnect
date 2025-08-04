using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;

public class PostLikeBuilderFactory
{
    private readonly ObjectBuilderFactory<PostLike> _objectBuilderFactory = new();

    public PostLikeBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var entityBuilder = new PostLikeBuilder(objectBuilder, post, user);

        return entityBuilder;
    }
}
