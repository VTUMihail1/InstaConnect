namespace InstaConnect.Posts.Application.Tests.Integration.Features.Users.Commands;

public class AddUserIntegrationTests : BaseUserApplicationIntegrationTest
{
    private readonly AddUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddUserCommandRequestBuilder _requestBuilder;
    private readonly AddUserCommandRequest _request;

    public AddUserIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
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
    public async Task SendAsync_ShouldThrowUserAlreadyExistsException_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithProfileImage(User.Id).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowUserAlreadyExistsExceptionAsync(request.Id);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldThrowUserAlreadyExistsException_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithId(User.Id, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowUserAlreadyExistsExceptionAsync(request.Id);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserEmailAlreadyExistsException_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithEmail(User.Email).Build();

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
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowUserEmailAlreadyExistsExceptionAsync(request.Email);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNameAlreadyExistsException_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithName(User.Name).Build();

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
        await ServiceScope.AddUserAsync(User, CancellationToken);
        var request = _requestBuilder.WithName(User.Name, transformer).Build();

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
    public async Task SendAsync_ShouldAddUser_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
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
        await ApplicationSender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(_request.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(_request);
    }
}
