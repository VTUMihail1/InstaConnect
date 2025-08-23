using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;

public class AddPostCommentApiRequestBuilder
{
    private readonly ObjectBuilder<AddPostCommentApiRequest> _objectBuilder;

    public AddPostCommentApiRequestBuilder(ObjectBuilder<AddPostCommentApiRequest> objectBuilder, Post post, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(user.Id);
        WithContent(PostCommentDataFaker.GetContent());
    }

    public AddPostCommentApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public AddPostCommentApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostCommentApiRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Body.Content, content, transformer);

        return this;
    }

    public AddPostCommentApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
