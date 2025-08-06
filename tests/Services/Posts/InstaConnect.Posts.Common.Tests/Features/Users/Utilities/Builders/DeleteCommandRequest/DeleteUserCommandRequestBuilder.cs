using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Users.Application.Features.Users.Commands.Add;
using InstaConnect.Users.Application.Features.Users.Commands.Delete;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.DeleteApiRequest;

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
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public DeleteUserCommandRequest Create()
    {
        return _objectBuilder.Create();
    }
}
