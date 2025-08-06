using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Users.Application.Features.Users.Commands.Add;
using InstaConnect.Users.Application.Features.Users.Commands.Delete;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.DeleteApiRequest;

public class DeleteUserCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeleteUserCommandRequest> _objectBuilderFactory = new();

    public DeleteUserCommandRequestBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeleteUserCommandRequestBuilder(objectBuilder, user);

        return requestBuilder;
    }
}
