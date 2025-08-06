using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Users.Application.Features.Users.Commands.Add;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.UpdateApiRequest;

public class UpdateUserCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UpdateUserCommandRequest> _objectBuilderFactory = new();

    public UpdateUserCommandRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdateUserCommandRequestBuilder(objectBuilder);

        return requestBuilder;
    }
}
