using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddCommandRequest;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.DeleteApiRequest;

public class DeletePostApiRequestBuilder
{
    private readonly ObjectBuilder<DeletePostApiRequest> _objectBuilder;

    public DeletePostApiRequestBuilder(ObjectBuilder<DeletePostApiRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(PostDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
    }

    public DeletePostApiRequestBuilder(ObjectBuilder<DeletePostApiRequest> objectBuilder, Post post)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(post.UserId);
    }

    public DeletePostApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
