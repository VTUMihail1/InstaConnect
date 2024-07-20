using FluentAssertions;
using InstaConnect.Messages.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit.Testing;

namespace InstaConnect.Messages.Web.FunctionalTests.Tests.Consumers;

public class UserDeletedEventConsumerFunctionalTests : BaseMessageFunctionalTest
{
    public UserDeletedEventConsumerFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {
    }

    [Fact]
    public async Task Consume_ShouldReceiveEvent_WhenUserDeletedEventIsRaised()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = existingUserId
        };

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
