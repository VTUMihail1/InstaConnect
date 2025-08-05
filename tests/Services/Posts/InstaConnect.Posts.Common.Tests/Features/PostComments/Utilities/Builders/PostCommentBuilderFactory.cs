using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;

public class PostCommentBuilderFactory
{
    private readonly ObjectBuilderFactory<PostComment> _objectBuilderFactory = new();

    public PostCommentBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var entityBuilder = new PostCommentBuilder(objectBuilder, post, user);

        return entityBuilder;
    }
}
