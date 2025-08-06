using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Builders;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.DeleteApiRequest;

public class DeleteUserEventRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UserDeletedEventRequest> _objectBuilderFactory = new();

    public DeleteUserEventRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeleteUserEventRequestBuilder(objectBuilder);

        return requestBuilder;
    }
}
