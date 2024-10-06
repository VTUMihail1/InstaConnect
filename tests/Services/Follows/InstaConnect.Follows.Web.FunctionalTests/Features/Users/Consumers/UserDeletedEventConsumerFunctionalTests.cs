using FluentAssertions;
using InstaConnect.Follows.Web.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Follows.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit.Testing;

namespace InstaConnect.Follows.Web.FunctionalTests.Features.Users.Consumers;

public class UserDeletedEventConsumerFunctionalTests : BaseUserFunctionalTest
{
    public UserDeletedEventConsumerFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {
    }

    [Fact]
    public async Task Consume_ShouldReceiveEvent_WhenUserDeletedEventIsRaised()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userDeletedEvent = new UserDeletedEvent(existingUserId);

        // Act
        await TestHarness.Start();
        await TestHarness.Bus.Publish(userDeletedEvent, CancellationToken);
        await TestHarness.InactivityTask;
        await TestHarness.Stop();

        var result = await TestHarness.Consumed.Any<UserDeletedEvent>(m => m.Context.Message.Id == existingUserId, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
