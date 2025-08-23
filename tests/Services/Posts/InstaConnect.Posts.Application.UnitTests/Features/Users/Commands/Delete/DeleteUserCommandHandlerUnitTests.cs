using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Users.Application.Features.Users.Commands.Delete;
using InstaConnect.Users.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.DeleteApiRequest;

namespace InstaConnect.Users.Application.UnitTests.Features.Users.Commands.Delete;

public class DeleteUserCommandHandlerUnitTests : BaseUserApplicationUnitTest
{
    private readonly DeleteUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteUserCommandRequestBuilder _requestBuilder;
    private readonly DeleteUserCommandRequest _request;

    private readonly DeleteUserCommandHandler _handler;

    public DeleteUserCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _handler = new(UserService, ApplicationMapper);
    }

    [Fact]
    public async Task Handle_ShouldCallUserServiceDeleteAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await UserService.ShouldReceiveOneDeleteAsync(_request, CancellationToken);
    }
}
