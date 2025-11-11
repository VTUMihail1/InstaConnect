using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Builders;

public class DeleteUserCommandRequestBuilder
{
    private string _id;

    public DeleteUserCommandRequestBuilder(User user)
    {
        _id = user.Id;
    }

    public DeleteUserCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public DeleteUserCommandRequest Build()
    {
        return new(_id);
    }
}
