using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Users.Application.Features.Users.Commands.Add;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.AddApiRequest;

public class AddUserCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddUserCommandRequest> _objectBuilderFactory = new();

    public AddUserCommandRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddUserCommandRequestBuilder(objectBuilder);

        return requestBuilder;
    }
}
