using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddCommandRequest;
public class AddPostCommentCommandRequestBuilder
{
    private readonly ObjectBuilder<AddPostCommentCommandRequest> _objectBuilder;

    public AddPostCommentCommandRequestBuilder(ObjectBuilder<AddPostCommentCommandRequest> objectBuilder, Post post, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(user.Id);
        WithContent(PostCommentDataFaker.GetContent());
    }

    public AddPostCommentCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public AddPostCommentCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostCommentCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Content, content, transformer);

        return this;
    }

    public AddPostCommentCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
