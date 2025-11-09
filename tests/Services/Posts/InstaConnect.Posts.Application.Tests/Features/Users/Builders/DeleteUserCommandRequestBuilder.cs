namespace InstaConnect.Posts.Application.Tests.Features.Users.Builders;

public class DeleteUserCommandRequestBuilder
{
    private readonly ObjectBuilder<DeleteUserCommandRequest> _objectBuilder;

    public DeleteUserCommandRequestBuilder(ObjectBuilder<DeleteUserCommandRequest> objectBuilder, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(user.Id);
    }

    public DeleteUserCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public DeleteUserCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
