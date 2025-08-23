using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Users.Application.Features.Users.Commands.Add;
using InstaConnect.Users.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.UpdateApiRequest;

namespace InstaConnect.Users.Application.UnitTests.Features.Users.Commands.Update;

public class UpdateUserCommandHandlerUnitTests : BaseUserApplicationUnitTest
{
    private readonly UpdateUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdateUserCommandRequestBuilder _requestBuilder;
    private readonly UpdateUserCommandRequest _request;

    private readonly UpdateUserCommandHandler _handler;

    public UpdateUserCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _handler = new(UserService, ApplicationMapper);

        UserService.SetupUpdateCommand(_request, User, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User);
    }

    [Fact]
    public async Task Handle_ShouldCallUserServiceUpdateAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await UserService.ShouldReceiveOneUpdateAsync(_request, CancellationToken);
    }
}
