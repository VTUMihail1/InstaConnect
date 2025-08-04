using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;

public class AddPostLikeApiRequestBuilder
{
    private readonly ObjectBuilder<AddPostLikeApiRequest> _objectBuilder;

    public AddPostLikeApiRequestBuilder(ObjectBuilder<AddPostLikeApiRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(PostLikeDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
    }

    public AddPostLikeApiRequestBuilder(ObjectBuilder<AddPostLikeApiRequest> objectBuilder, Post post, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(user.Id);
    }

    public AddPostLikeApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public AddPostLikeApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostLikeApiRequest Create(IStringTransformer? transformer = null)
    {
        return _objectBuilder.Create();
    }
}
