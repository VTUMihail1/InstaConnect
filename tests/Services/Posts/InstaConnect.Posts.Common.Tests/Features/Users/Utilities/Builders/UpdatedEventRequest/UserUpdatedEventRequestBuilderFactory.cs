using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Builders;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.UpdateApiRequest;

public class UserUpdatedEventRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UserUpdatedEventRequest> _objectBuilderFactory = new();

    public UserUpdatedEventRequestBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UserUpdatedEventRequestBuilder(objectBuilder, user);

        return requestBuilder;
    }
}
