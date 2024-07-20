using FluentAssertions;
using InstaConnect.Messages.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit.Testing;

namespace InstaConnect.Messages.Web.FunctionalTests.Tests.Consumers;

public class UserUpdatedEventConsumerFunctionalTests : BaseMessageFunctionalTest
{
    public UserUpdatedEventConsumerFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {
    }

    [Fact]
    public async Task Consume_ShouldReceiveEvent_WhenUserUpdatedEventIsRaised()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userUpdatedEvent = new UserUpdatedEvent()
        {
            Id = existingUserId,
            FirstName = MessageFunctionalTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageFunctionalTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageFunctionalTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageFunctionalTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageFunctionalTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        // Act
        await TestHarness.Start();
        await TestHarness.Bus.Publish(userUpdatedEvent, CancellationToken);
        await TestHarness.InactivityTask;
        await TestHarness.Stop();

        var result = await TestHarness.Consumed.Any<UserUpdatedEvent>(m =>
                              m.Context.Message.Id == existingUserId &&
                              m.Context.Message.FirstName == MessageFunctionalTestConfigurations.EXISTING_SENDER_FIRST_NAME &&
                              m.Context.Message.LastName == MessageFunctionalTestConfigurations.EXISTING_SENDER_LAST_NAME &&
                              m.Context.Message.UserName == MessageFunctionalTestConfigurations.EXISTING_SENDER_NAME &&
                              m.Context.Message.Email == MessageFunctionalTestConfigurations.EXISTING_SENDER_EMAIL &&
                              m.Context.Message.ProfileImage == MessageFunctionalTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
