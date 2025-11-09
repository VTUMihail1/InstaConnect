namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Users.EventHandlers;

public class AddUserPresentationTests : BaseUserPresentationFunctionalTest
{
    private readonly UserAddedEventRequestBuilderFactory _requestBuilderFactory;
    private readonly UserAddedEventRequestBuilder _requestBuilder;
    private readonly UserAddedEventRequest _request;

    public AddUserPresentationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create();
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await Task.CompletedTask;
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
        var eventWasFaulted = await EventHarness.HasFaultedUserAddedEventRequestAsync(request, errorMessage, CancellationToken);

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
        var eventWasFaulted = await EventHarness.HasFaultedUserAddedEventRequestAsync(request, errorMessage, CancellationToken);

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
        var eventWasFaulted = await EventHarness.HasFaultedUserAddedEventRequestAsync(request, errorMessage, CancellationToken);

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
        var eventWasFaulted = await EventHarness.HasFaultedUserAddedEventRequestAsync(request, errorMessage, CancellationToken);

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
        var eventWasFaulted = await EventHarness.HasFaultedUserAddedEventRequestAsync(request, errorMessage, CancellationToken);

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
        var eventWasFaulted = await EventHarness.HasFaultedUserAddedEventRequestAsync(request, errorMessage, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldHaveUserAlreadyExistsErrorMessage_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithProfileImage(User.Id).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserAddedEventRequestWithAlreadyExistsMessageAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldHaveUserAlreadyExistsErrorMessage_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithId(User.Id, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserAddedEventRequestWithAlreadyExistsMessageAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldHaveUserEmailAlreadyExistsErrorMessage_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithEmail(User.Email).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserAddedEventRequestWithEmailAlreadyExistsMessageAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldHaveUserEmailAlreadyExistsErrorMessage_WhenEmailIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserAddedEventRequestWithEmailAlreadyExistsMessageAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldHaveUserNameAlreadyExistsErrorMessage_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithName(User.Name).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserAddedEventRequestWithNameAlreadyExistsMessageAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldHaveUserNameAlreadyExistsErrorMessage_WhenNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithName(User.Name, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserAddedEventRequestWithNameAlreadyExistsMessageAsync(request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldConsumeUserAddedEvent_WhenRequestIsValid()
    {
        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasConsumed = await EventHarness.HasConsumedUserAddedEventRequestAsync(_request, CancellationToken);

        // Assert
        eventWasConsumed.ShouldBeTrue();
    }

    [Theory]
    [UserProfileImageNullData]
    [UserProfileImageEmptyData]
    public async Task SendAsync_ShouldConsumeUserAddedEvent_WhenProfileImageIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(_request.ProfileImage, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasConsumed = await EventHarness.HasConsumedUserAddedEventRequestAsync(request, CancellationToken);

        // Assert
        eventWasConsumed.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldAddUser_WhenRequestIsValid()
    {
        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(_request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(_request);
    }

    [Theory]
    [UserProfileImageNullData]
    [UserProfileImageEmptyData]
    public async Task SendAsync_ShouldAddUser_WhenProfileImageIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(_request.ProfileImage, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(_request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(_request);
    }
}
