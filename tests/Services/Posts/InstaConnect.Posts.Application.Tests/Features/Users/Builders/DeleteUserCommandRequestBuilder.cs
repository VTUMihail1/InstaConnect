using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Builders;

public class DeleteUserCommandRequestBuilder
{
    private string _id;

    public DeleteUserCommandRequestBuilder(User user)
    {
        _id = user.Id.Id;
    }

    public DeleteUserCommandRequestBuilder WithId(User user, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public DeleteUserCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public DeleteUserCommandRequest Build()
    {
        return new(_id);
    }
}
