using InstaConnect.Follows.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Follows.Presentation.FunctionalTests.Utilities;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Users.Consumers;

public class UserUpdatedEventConsumerFunctionalTests : BaseUserFunctionalTest
{
    public UserUpdatedEventConsumerFunctionalTests(FollowsFunctionalTestWebAppFactory followFunctionalTestWebAppFactory) : base(followFunctionalTestWebAppFactory)
    {
    }

    // TODO: Fix the tests to not collide with each other
    //[Fact]
    //public async Task Consume_ShouldNotUpdateUser_WhenUserUpdatedEventIsInvalid()
    //{
    //    // Arrange
    //    var existingUserId = await CreateUserAsync(CancellationToken);
    //    var userUpdatedEvent = new UserUpdatedEvent(
    //        UserTestUtilities.InvalidId,
    //        UserTestUtilities.ValidUpdateName,
    //        UserTestUtilities.ValidEmail,
    //        UserTestUtilities.ValidUpdateFirstName,
    //        UserTestUtilities.ValidUpdateLastName,
    //        UserTestUtilities.ValidUpdateProfileImage);

    //    // Act
    //    await TestHarness.Bus.Publish(userUpdatedEvent, CancellationToken);
    //    await TestHarness.Published.Any<UserUpdatedEvent>();
    //    await TestHarness.Consumed.Any<UserUpdatedEvent>();

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
    //public async Task Consume_ShouldUpdateUser_WhenUserUpdatedEventIsValid()
    //{
    //    // Arrange
    //    var existingUserId = await CreateUserAsync(CancellationToken);
    //    var userUpdatedEvent = new UserUpdatedEvent(
    //        existingUserId,
    //        UserTestUtilities.ValidUpdateName,
    //        UserTestUtilities.ValidEmail,
    //        UserTestUtilities.ValidUpdateFirstName,
    //        UserTestUtilities.ValidUpdateLastName,
    //        UserTestUtilities.ValidUpdateProfileImage);

    //    // Act
    //    await TestHarness.Bus.Publish(userUpdatedEvent, CancellationToken);
    //    await TestHarness.Published.Any<UserUpdatedEvent>();
    //    await TestHarness.Consumed.Any<UserUpdatedEvent>();

    //    var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

    //    // Assert
    //    existingUser
    //        .Should()
    //        .Match<User>(m => m.Id == existingUserId &&
    //                          m.FirstName == UserTestUtilities.ValidUpdateFirstName &&
    //                          m.LastName == UserTestUtilities.ValidUpdateLastName &&
    //                          m.UserName == UserTestUtilities.ValidUpdateName &&
    //                          m.Email == UserTestUtilities.ValidEmail &&
    //                          m.ProfileImage == UserTestUtilities.ValidUpdateProfileImage);
    //}

    //[Fact]
    //public async Task Consume_ShouldUpdateUser_WhenUserUpdatedEventIsValidAndIdCaseDoesNotMatch()
    //{
    //    // Arrange
    //    var existingUserId = await CreateUserAsync(CancellationToken);
    //    var userUpdatedEvent = new UserUpdatedEvent(
    //        SharedTestUtilities.GetNonCaseMatchingString(existingUserId),
    //        UserTestUtilities.ValidUpdateName,
    //        UserTestUtilities.ValidEmail,
    //        UserTestUtilities.ValidUpdateFirstName,
    //        UserTestUtilities.ValidUpdateLastName,
    //        UserTestUtilities.ValidUpdateProfileImage);

    //    // Act
    //    await TestHarness.Bus.Publish(userUpdatedEvent, CancellationToken);
    //    await TestHarness.Published.Any<UserUpdatedEvent>();
    //    await TestHarness.Consumed.Any<UserUpdatedEvent>();

    //    var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

    //    // Assert
    //    existingUser
    //        .Should()
    //        .Match<User>(m => m.Id == existingUserId &&
    //                          m.FirstName == UserTestUtilities.ValidUpdateFirstName &&
    //                          m.LastName == UserTestUtilities.ValidUpdateLastName &&
    //                          m.UserName == UserTestUtilities.ValidUpdateName &&
    //                          m.Email == UserTestUtilities.ValidEmail &&
    //                          m.ProfileImage == UserTestUtilities.ValidUpdateProfileImage);
    //}

    //[Fact]
    //public async Task Consume_ShouldReceiveEvent_WhenUserUpdatedEventIsRaised()
    //{
    //    // Arrange
    //    var existingUserId = await CreateUserAsync(CancellationToken);
    //    var userUpdatedEvent = new UserUpdatedEvent(
    //        existingUserId, 
    //        UserTestUtilities.ValidUpdateName, 
    //        UserTestUtilities.ValidEmail, 
    //        UserTestUtilities.ValidUpdateFirstName, 
    //        UserTestUtilities.ValidUpdateLastName, 
    //        UserTestUtilities.ValidUpdateProfileImage);

    //    // Act
    //    await TestHarness.Bus.Publish(userUpdatedEvent, CancellationToken);
    //    await TestHarness.Published.Any<UserUpdatedEvent>();
    //    await TestHarness.Consumed.Any<UserUpdatedEvent>();

    //    var result = await TestHarness.Consumed.Any<UserUpdatedEvent>(m =>
    //                          m.Context.Message.Id == existingUserId &&
    //                          m.Context.Message.FirstName == UserTestUtilities.ValidUpdateFirstName &&
    //                          m.Context.Message.LastName == UserTestUtilities.ValidUpdateLastName &&
    //                          m.Context.Message.UserName == UserTestUtilities.ValidUpdateName &&
    //                          m.Context.Message.Email == UserTestUtilities.ValidEmail &&
    //                          m.Context.Message.ProfileImage == UserTestUtilities.ValidUpdateProfileImage, CancellationToken);

    //    // Assert
    //    result.Should().BeTrue();
    //}
}
