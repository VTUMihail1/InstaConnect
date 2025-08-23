using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Email;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.FirstName;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.LastName;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.ProfileImage;
using InstaConnect.Posts.Common.Tests.Features.Utilities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.UpdateApiRequest;

namespace InstaConnect.Users.Application.PresentationTests.Features.Users.Commands;

public class UpdateUserPresentationTests : BaseUserPresentationFunctionalTest
{
    private readonly UserUpdatedEventRequestBuilderFactory _requestBuilderFactory;
    private readonly UserUpdatedEventRequestBuilder _requestBuilder;
    private readonly UserUpdatedEventRequest _request;

    public UpdateUserPresentationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldHaveErrorMessage_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserUpdatedEventRequestAsync(request, errorMessage, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserNameNullWithMessageData]
    [UserNameEmptyWithMessageData]
    [UserNameTooShortWithMessageData]
    [UserNameTooLongWithMessageData]
    public async Task SendAsync_ShouldHaveErrorMessage_WhenNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithName(_request.Name, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserUpdatedEventRequestAsync(request, errorMessage, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserFirstNameNullWithMessageData]
    [UserFirstNameEmptyWithMessageData]
    [UserFirstNameTooShortWithMessageData]
    [UserFirstNameTooLongWithMessageData]
    public async Task SendAsync_ShouldHaveErrorMessage_WhenFirstNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithFirstName(_request.FirstName, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserUpdatedEventRequestAsync(request, errorMessage, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserLastNameNullWithMessageData]
    [UserLastNameEmptyWithMessageData]
    [UserLastNameTooShortWithMessageData]
    [UserLastNameTooLongWithMessageData]
    public async Task SendAsync_ShouldHaveErrorMessage_WhenLastNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithLastName(_request.LastName, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserUpdatedEventRequestAsync(request, errorMessage, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserEmailNullWithMessageData]
    [UserEmailEmptyWithMessageData]
    [UserEmailTooShortWithMessageData]
    [UserEmailTooLongWithMessageData]
    public async Task SendAsync_ShouldHaveErrorMessage_WhenEmailIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(_request.Email, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserUpdatedEventRequestAsync(request, errorMessage, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserProfileImageTooLongWithMessageData]
    public async Task SendAsync_ShouldHaveErrorMessage_WhenProfileImageIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(_request.ProfileImage, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserUpdatedEventRequestAsync(request, errorMessage, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldHaveUserNotFoundErrorMessage_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserUpdatedEventRequestWithNotFoundMessageAsync(_request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldHaveUserEmailAlreadyExistsErrorMessage_WhenRequestIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithEmail(user.Email).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserUpdatedEventRequestWithEmailAlreadyExistsMessageAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldHaveUserEmailAlreadyExistsErrorMessage_WhenEmailIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithEmail(user.Email, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserUpdatedEventRequestWithEmailAlreadyExistsMessageAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldHaveUserNameAlreadyExistsErrorMessage_WhenRequestIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithName(user.Name).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserUpdatedEventRequestWithNameAlreadyExistsMessageAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldHaveUserNameAlreadyExistsErrorMessage_WhenNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithName(user.Name, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserUpdatedEventRequestWithNameAlreadyExistsMessageAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldConsumeUserUpdatedEvent_WhenRequestIsValid()
    {
        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasConsumedUserUpdatedEventRequestAsync(_request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldConsumeUserUpdatedEvent_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasConsumedUserUpdatedEventRequestAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldConsumeUserUpdatedEvent_WhenNameIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(_request.Name, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasConsumedUserUpdatedEventRequestAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldConsumeUserUpdatedEvent_WhenNameHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithName(User.Name).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasConsumedUserUpdatedEventRequestAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldConsumeUserUpdatedEvent_WhenNameIsValidAndHasNotChanged(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(User.Name, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasConsumedUserUpdatedEventRequestAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldConsumeUserUpdatedEvent_WhenEmailIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(_request.Email, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasConsumedUserUpdatedEventRequestAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldConsumeUserUpdatedEvent_WhenEmailHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User.Email).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasConsumedUserUpdatedEventRequestAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldConsumeUserUpdatedEvent_WhenEmailIsValidAndHasNotChanged(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasConsumedUserUpdatedEventRequestAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserProfileImageNullData]
    [UserProfileImageEmptyData]
    public async Task SendAsync_ShouldConsumeUserUpdatedEvent_WhenProfileImageIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(_request.ProfileImage, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasConsumedUserUpdatedEventRequestAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateUser_WhenRequestIsValid()
    {
        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(_request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldUpdateUser_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldUpdateUser_WhenNameIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(_request.Name, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateUser_WhenNameHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithName(User.Name).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldUpdateUser_WhenNameIsValidAndHasNotChanged(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(User.Name, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldUpdateUser_WhenEmailIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(_request.Email, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateUser_WhenEmailHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User.Email).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldUpdateUser_WhenEmailIsValidAndHasNotChanged(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Theory]
    [UserProfileImageNullData]
    [UserProfileImageEmptyData]
    public async Task SendAsync_ShouldUpdateUser_WhenRequestAndProfileImageAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(_request.ProfileImage, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(_request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }
}
