using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Builders;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.AddApiRequest;

public class AddUserEventRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UserAddedEventRequest> _objectBuilderFactory = new();

    public AddUserEventRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddUserEventRequestBuilder(objectBuilder);

        return requestBuilder;
    }
}
