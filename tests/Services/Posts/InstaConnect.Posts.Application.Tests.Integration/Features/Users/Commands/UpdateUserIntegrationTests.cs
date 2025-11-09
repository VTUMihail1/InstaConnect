namespace InstaConnect.Posts.Application.Tests.Integration.Features.Users.Commands;

public class UpdateUserIntegrationTests : BaseUserApplicationIntegrationTest
{
    private readonly UpdateUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdateUserCommandRequestBuilder _requestBuilder;
    private readonly UpdateUserCommandRequest _request;

    public UpdateUserIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
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
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [UserNameNullWithMessageData]
    [UserNameEmptyWithMessageData]
    [UserNameTooShortWithMessageData]
    [UserNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithName(_request.Name, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [UserFirstNameNullWithMessageData]
    [UserFirstNameEmptyWithMessageData]
    [UserFirstNameTooShortWithMessageData]
    [UserFirstNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenFirstNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithFirstName(_request.FirstName, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [UserLastNameNullWithMessageData]
    [UserLastNameEmptyWithMessageData]
    [UserLastNameTooShortWithMessageData]
    [UserLastNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenLastNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithLastName(_request.LastName, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [UserEmailNullWithMessageData]
    [UserEmailEmptyWithMessageData]
    [UserEmailTooShortWithMessageData]
    [UserEmailTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenEmailIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(_request.Email, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [UserProfileImageTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenProfileImageIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(_request.ProfileImage, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var action = async () => await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        await action.ShouldThrowUserAlreadyExistsExceptionAsync(_request.Id);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserEmailAlreadyExistsException_WhenRequestIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithEmail(user.Email).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowUserEmailAlreadyExistsExceptionAsync(request.Email);
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

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowUserEmailAlreadyExistsExceptionAsync(request.Email);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNameAlreadyExistsException_WhenRequestIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithName(user.Name).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowUserNameAlreadyExistsExceptionAsync(request.Name);
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

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowUserNameAlreadyExistsExceptionAsync(request.Name);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(_request.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(user);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(user);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenNameIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(_request.Name, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(user);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenNameHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithName(User.Name).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(user);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(User.Name, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(user);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenEmailIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(_request.Email, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(user);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenEmailHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User.Email).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(user);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(user);
    }

    [Theory]
    [UserProfileImageNullData]
    [UserProfileImageEmptyData]
    public async Task SendAsync_ShouldReturnResponse_WhenProfileImageIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(_request.ProfileImage, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(user);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateUser_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
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
        await ApplicationSender.SendAsync(request, CancellationToken);
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
        await ApplicationSender.SendAsync(request, CancellationToken);
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
        await ApplicationSender.SendAsync(request, CancellationToken);
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
        await ApplicationSender.SendAsync(request, CancellationToken);
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
        await ApplicationSender.SendAsync(request, CancellationToken);
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
        await ApplicationSender.SendAsync(request, CancellationToken);
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
        await ApplicationSender.SendAsync(request, CancellationToken);
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
        await ApplicationSender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(_request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }
}
