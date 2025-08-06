using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Builders;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.UpdateApiRequest;

public class UpdateUserEventRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UserUpdatedEventRequest> _objectBuilderFactory = new();

    public UpdateUserEventRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdateUserEventRequestBuilder(objectBuilder);

        return requestBuilder;
    }
}
