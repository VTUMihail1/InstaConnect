namespace InstaConnect.Chats.Application.Tests.Integration.Features.Users.Commands;

public class UpdateUserIntegrationTests : BaseUserApplicationCommandIntegrationTest
{
    private readonly UpdateUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdateUserCommandRequestBuilder _requestBuilder;
    private readonly UpdateUserCommandRequest _request;

    public UpdateUserIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserNameNullWithMessageData]
    [UserNameEmptyWithMessageData]
    [UserNameTooShortWithMessageData]
    [UserNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForNameAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserFirstNameNullWithMessageData]
    [UserFirstNameEmptyWithMessageData]
    [UserFirstNameTooShortWithMessageData]
    [UserFirstNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenFirstNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithFirstName(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForFirstNameAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserLastNameNullWithMessageData]
    [UserLastNameEmptyWithMessageData]
    [UserLastNameTooShortWithMessageData]
    [UserLastNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenLastNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithLastName(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForLastNameAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserEmailNullWithMessageData]
    [UserEmailEmptyWithMessageData]
    [UserEmailTooShortWithMessageData]
    [UserEmailTooLongWithMessageData]
    [UserEmailInvalidWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenEmailIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForEmailAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserProfileImageTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenProfileImageIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForProfileImageAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserUpdatedAtUtcEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUpdatedAtUtcIsInvalid(
        IDateTimeOffsetTransformer transformer, IDateTimeOffsetMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUpdatedAtUtc(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForUpdatedAtUtcAsync(
            messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Assert
        await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserEmailAlreadyExistsException_WhenRequestIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithEmail(user.Email).Build();

        // Assert
        await Sender.ShouldThrowUserEmailAlreadyExistsExceptionAsync(request, CancellationToken);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldThrowUserEmailAlreadyExistsException_WhenEmailIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithEmail(user.Email, transformer).Build();

        // Assert
        await Sender.ShouldThrowUserEmailAlreadyExistsExceptionAsync(request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNameAlreadyExistsException_WhenRequestIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithName(user.Name).Build();

        // Assert
        await Sender.ShouldThrowUserNameAlreadyExistsExceptionAsync(request, CancellationToken);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldThrowUserNameAlreadyExistsException_WhenNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithName(user.Name, transformer).Build();

        // Assert
        await Sender.ShouldThrowUserNameAlreadyExistsExceptionAsync(request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(user, _request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(user, request);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenNameIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(user, request);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenNameHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithName(User.Name).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(user, request);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(User.Name, transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(user, request);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenEmailIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(user, request);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenEmailHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User.Email).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(user, request);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(user, request);
    }

    [Theory]
    [UserProfileImageNullData]
    [UserProfileImageEmptyData]
    public async Task SendAsync_ShouldReturnResponse_WhenProfileImageIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(user, request);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateUser_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        user.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldUpdateUser_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldUpdateUser_WhenNameIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateUser_WhenNameHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithName(User.Name).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

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
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldUpdateUser_WhenEmailIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateUser_WhenEmailHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User.Email).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

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
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

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
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }
}
