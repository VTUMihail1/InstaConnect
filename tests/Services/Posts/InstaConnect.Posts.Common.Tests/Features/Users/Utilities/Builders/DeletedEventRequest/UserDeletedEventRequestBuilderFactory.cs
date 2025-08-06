using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Builders;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.DeleteApiRequest;

public class UserDeletedEventRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UserDeletedEventRequest> _objectBuilderFactory = new();

    public UserDeletedEventRequestBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UserDeletedEventRequestBuilder(objectBuilder, user);

        return requestBuilder;
    }
}
