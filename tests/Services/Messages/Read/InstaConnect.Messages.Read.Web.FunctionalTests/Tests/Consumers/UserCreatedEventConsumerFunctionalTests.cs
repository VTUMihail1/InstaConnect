using FluentAssertions;
using InstaConnect.Messages.Write.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit.Testing;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Tests.Consumers;

public class UserCreatedEventConsumerFunctionalTests : BaseMessageFunctionalTest
{
    public UserCreatedEventConsumerFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {
    }

    [Fact]
    public async Task Consume_ShouldReceiveEvent_WhenUserCreatedEventIsRaised()
    {
        // Arrange
        var userUpdatedEvent = new UserUpdatedEvent()
        {
            Id = MessageFunctionalTestConfigurations.NON_EXISTING_MESSAGE_ID,
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
                              m.Context.Message.Id == MessageFunctionalTestConfigurations.NON_EXISTING_MESSAGE_ID &&
                              m.Context.Message.FirstName == MessageFunctionalTestConfigurations.EXISTING_SENDER_FIRST_NAME &&
                              m.Context.Message.LastName == MessageFunctionalTestConfigurations.EXISTING_SENDER_LAST_NAME &&
                              m.Context.Message.UserName == MessageFunctionalTestConfigurations.EXISTING_SENDER_NAME &&
                              m.Context.Message.Email == MessageFunctionalTestConfigurations.EXISTING_SENDER_EMAIL &&
                              m.Context.Message.ProfileImage == MessageFunctionalTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
