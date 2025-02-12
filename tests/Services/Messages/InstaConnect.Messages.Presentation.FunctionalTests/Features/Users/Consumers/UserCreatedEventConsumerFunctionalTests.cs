using InstaConnect.Follows.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Messages.Presentation.FunctionalTests.Utilities;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Users.Consumers;

public class UserCreatedEventConsumerFunctionalTests : BaseUserFunctionalTest
{
    public UserCreatedEventConsumerFunctionalTests(MessagesWebApplicationFactory messagesWebApplicationFactory) : base(messagesWebApplicationFactory)
    {
    }

    // TODO: Fix the tests to not collide with each other
    //[Fact]
    //public async Task Consume_ShouldNotCreateUser_WhenUserCreatedEventIsInvalid()
    //{
    //    // Arrange
    //    var existingUserId = await CreateUserAsync(CancellationToken);
    //    var userCreatedEvent = new UserCreatedEvent(
    //        existingUserId,
    //        UserTestUtilities.ValidAddName,
    //        UserTestUtilities.ValidAddEmail,
    //        UserTestUtilities.ValidAddFirstName,
    //        UserTestUtilities.ValidAddLastName,
    //        UserTestUtilities.ValidAddProfileImage);

    //    // Act
    //    await TestHarness.Bus.Publish(userCreatedEvent, CancellationToken);
    //    await TestHarness.Published.Any<UserCreatedEvent>();
    //    await TestHarness.Consumed.Any<UserCreatedEvent>();

    //    var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

    //    // Assert
    //    existingUser
    //        .Should()
    //        .Match<User>(m => m.Id == existingUserId &&
    //                          m.FirstName == UserTestUtilities.ValidFirstName &&
    //                          m.LastName == UserTestUtilities.ValidLastName &&
    //                          m.UserName == UserTestUtilities.ValidName &&
    //                          m.Email == UserTestUtilities.ValidEmail &&
    //                          m.ProfileImage == UserTestUtilities.ValidProfileImage);
    //}

    //[Fact]
    //public async Task Consume_ShouldCreateUser_WhenUserCreatedEventIsValid()
    //{
    //    // Arrange
    //    var existingUserId = await CreateUserAsync(CancellationToken);
    //    var userCreatedEvent = new UserCreatedEvent(
    //        UserTestUtilities.InvalidId,
    //        UserTestUtilities.ValidAddName,
    //        UserTestUtilities.ValidAddEmail,
    //        UserTestUtilities.ValidAddFirstName,
    //        UserTestUtilities.ValidAddLastName,
    //        UserTestUtilities.ValidAddProfileImage);

    //    // Act
    //    await TestHarness.Bus.Publish(userCreatedEvent, CancellationToken);
    //    await TestHarness.Published.Any<UserCreatedEvent>();
    //    await TestHarness.Consumed.Any<UserCreatedEvent>();

    //    var existingUser = await UserWriteRepository.GetByIdAsync(UserTestUtilities.InvalidId, CancellationToken);

    //    // Assert
    //    existingUser
    //        .Should()
    //        .Match<User>(m => m.Id == UserTestUtilities.InvalidId &&
    //                          m.FirstName == UserTestUtilities.ValidAddFirstName &&
    //                          m.LastName == UserTestUtilities.ValidAddLastName &&
    //                          m.UserName == UserTestUtilities.ValidAddName &&
    //                          m.Email == UserTestUtilities.ValidAddEmail &&
    //                          m.ProfileImage == UserTestUtilities.ValidAddProfileImage);
    //}

    //[Fact]
    //public async Task Consume_ShouldCreateUser_WhenUserCreatedEventIsValidAndIdCaseDoesNotMatch()
    //{
    //    // Arrange
    //    var existingUserId = await CreateUserAsync(CancellationToken);
    //    var userCreatedEvent = new UserCreatedEvent(
    //        SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.InvalidId),
    //        UserTestUtilities.ValidAddName,
    //        UserTestUtilities.ValidAddEmail,
    //        UserTestUtilities.ValidAddFirstName,
    //        UserTestUtilities.ValidAddLastName,
    //        UserTestUtilities.ValidAddProfileImage);

    //    // Act
    //    await TestHarness.Bus.Publish(userCreatedEvent, CancellationToken);
    //    await TestHarness.Published.Any<UserCreatedEvent>();
    //    await TestHarness.Consumed.Any<UserCreatedEvent>();

    //    var existingUser = await UserWriteRepository.GetByIdAsync(UserTestUtilities.InvalidId, CancellationToken);

    //    // Assert
    //    existingUser
    //        .Should()
    //        .Match<User>(m => m.Id == SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.InvalidId) &&
    //                          m.FirstName == UserTestUtilities.ValidAddFirstName &&
    //                          m.LastName == UserTestUtilities.ValidAddLastName &&
    //                          m.UserName == UserTestUtilities.ValidAddName &&
    //                          m.Email == UserTestUtilities.ValidAddEmail &&
    //                          m.ProfileImage == UserTestUtilities.ValidAddProfileImage);
    //}

    //[Fact]
    //public async Task Consume_ShouldReceiveEvent_WhenUserCreatedEventIsRaised()
    //{
    //    // Arrange
    //    var existingUserId = await CreateUserAsync(CancellationToken);
    //    var userCreatedEvent = new UserCreatedEvent(
    //        existingUserId,
    //        UserTestUtilities.ValidAddName,
    //        UserTestUtilities.ValidAddEmail,
    //        UserTestUtilities.ValidAddFirstName,
    //        UserTestUtilities.ValidAddLastName,
    //        UserTestUtilities.ValidAddProfileImage);

    //    // Act
    //    await TestHarness.Bus.Publish(userCreatedEvent, CancellationToken);
    //    await TestHarness.Published.Any<UserCreatedEvent>();
    //    await TestHarness.Consumed.Any<UserCreatedEvent>();

    //    var result = await TestHarness.Consumed.Any<UserCreatedEvent>(m =>
    //                          m.Context.Message.Id == existingUserId &&
    //                          m.Context.Message.FirstName == UserTestUtilities.ValidAddFirstName &&
    //                          m.Context.Message.LastName == UserTestUtilities.ValidAddLastName &&
    //                          m.Context.Message.UserName == UserTestUtilities.ValidAddName &&
    //                          m.Context.Message.Email == UserTestUtilities.ValidAddEmail &&
    //                          m.Context.Message.ProfileImage == UserTestUtilities.ValidAddProfileImage, CancellationToken);

    //    // Assert
    //    result.Should().BeTrue();
    //}
}
