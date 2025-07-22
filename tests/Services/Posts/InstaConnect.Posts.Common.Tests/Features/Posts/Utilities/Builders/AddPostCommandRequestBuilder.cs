using System.Runtime.CompilerServices;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
public class AddPostCommandRequestBuilder
{
    private readonly ObjectBuilder<AddPostCommandRequest> _objectBuilder = new();

    public AddPostCommandRequestBuilder() : this(new PostBuilder().Create())
    {
    }

    public AddPostCommandRequestBuilder(Post post)
    {
        WithUserId(post.UserId);
        WithTitle(post.Title);
        WithContent(post.Content);
    }

    public AddPostCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId, transformer);

        return this;
    }

    public AddPostCommandRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Title, title, transformer);

        return this;
    }

    public AddPostCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Content, content, transformer);

        return this;
    }

    public AddPostCommandRequest Create()
    {
        return _objectBuilder.Create();
    }
}
