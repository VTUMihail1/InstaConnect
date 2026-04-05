namespace InstaConnect.Identity.Application.Tests.Integration.Features.Users.Commands;

public class AddUserIntegrationTests : BaseUserApplicationCommandIntegrationTest
{
    private const string PasswordPropertyName = nameof(AddUserCommandRequest.Password);

    private readonly AddUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddUserCommandRequestBuilder _requestBuilder;
    private readonly AddUserCommandRequest _request;

    public AddUserIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create();
        _request = _requestBuilder.Build();
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
        await Sender.ShouldThrowInvalidValidationExceptionForNameAsync(messageTransformer, request, CancellationToken);
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
        await Sender.ShouldThrowInvalidValidationExceptionForFirstNameAsync(messageTransformer, request, CancellationToken);
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
        await Sender.ShouldThrowInvalidValidationExceptionForLastNameAsync(messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserEmailNullWithMessageData]
    [UserEmailEmptyWithMessageData]
    [UserEmailTooShortWithMessageData]
    [UserEmailTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenEmailIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForEmailAsync(messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserPasswordNullWithMessageData]
    [UserPasswordEmptyWithMessageData]
    [UserPasswordTooShortWithMessageData]
    [UserPasswordTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPasswordIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPassword(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForPasswordAsync(messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserConfirmPasswordNotEqualWithMessageData(PasswordPropertyName)]
    public async Task SendAsync_ShouldThrowValidationException_WhenConfirmPasswordIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithConfirmPassword(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForConfirmPasswordAsync(messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserEmailAlreadyTakenException_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithEmail(User.Email).Build();

        // Assert
        await Sender.ShouldThrowUserEmailAlreadyTakenExceptionAsync(request, CancellationToken);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldThrowUserEmailAlreadyTakenException_WhenEmailIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

        // Assert
        await Sender.ShouldThrowUserEmailAlreadyTakenExceptionAsync(request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNameAlreadyTakenException_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithName(User.Name).Build();

        // Assert
        await Sender.ShouldThrowUserNameAlreadyTakenExceptionAsync(request, CancellationToken);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithName(User.Name, transformer).Build();

        // Assert
        await Sender.ShouldThrowUserNameAlreadyTakenExceptionAsync(request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(user, _request);
    }

    [Theory]
    [UserProfileImageNullData]
    public async Task SendAsync_ShouldReturnResponse_WhenProfileImageIsValid(
        IFormFileTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(user, request);
    }

    [Fact]
    public async Task SendAsync_ShouldAddUser_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(_request, PasswordHasher);
    }

    [Theory]
    [UserProfileImageNullData]
    public async Task SendAsync_ShouldAddUser_WhenProfileImageIsValid(
        IFormFileTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request, PasswordHasher);
    }

    [Fact]
    public async Task SendAsync_ShouldAddEmailConfirmationToken_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Id, CancellationToken);

        // Assert
        user.EmailConfirmationTokens.ShouldNotBeEmpty();
    }

    [Theory]
    [UserProfileImageNullData]
    public async Task SendAsync_ShouldAddEmailConfirmationToken_WhenProfileImageIsValid(
        IFormFileTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Id, CancellationToken);

        // Assert
        user.EmailConfirmationTokens.ShouldNotBeEmpty();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishUserAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(user, CancellationToken);
    }

    [Theory]
    [UserProfileImageNullData]
    public async Task SendAsync_ShouldPublishUserAddedEvent_WhenRequestAndProfileImageAreValid(
        IFormFileTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(user, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(user.EmailConfirmationTokens, CancellationToken);
    }

    [Theory]
    [UserProfileImageNullData]
    public async Task SendAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestAndProfileImageAreValid(
        IFormFileTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(response.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(user.EmailConfirmationTokens, CancellationToken);
    }
}
