namespace InstaConnect.Identity.Application.Tests.Integration.Features.EmailConfirmationTokens.Commands;

public class VerifyEmailConfirmationTokenIntegrationTests : BaseEmailConfirmationTokenApplicationCommandIntegrationTest
{
    private readonly VerifyEmailConfirmationTokenCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly VerifyEmailConfirmationTokenCommandRequestBuilder _requestBuilder;
    private readonly VerifyEmailConfirmationTokenCommandRequest _request;

    public VerifyEmailConfirmationTokenIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(EmailConfirmationToken);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddEmailConfirmationTokenRangeAsync(User.EmailConfirmationTokens, CancellationToken);
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
        await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(messageTransformer, request, CancellationToken);
    }

    [Theory]
    [EmailConfirmationTokenValueNullWithMessageData]
    [EmailConfirmationTokenValueEmptyWithMessageData]
    [EmailConfirmationTokenValueTooShortWithMessageData]
    [EmailConfirmationTokenValueTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenValueIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithValue(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForValueAsync(messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Assert
        await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowEmailConfirmationTokenNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteEmailConfirmationTokenAsync(EmailConfirmationToken, CancellationToken);

        // Assert
        await Sender.ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserEmailAlreadyConfirmedException_WhenEmailIsConfirmed()
    {
        // Arrange
        var updatedUser = UserBuilder.WithConfirmedEmail().Build();
        await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

        // Assert
        await Sender.ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowForgotPasswordExpiredException_WhenIdIsInvalid()
    {
        // Arrange
        var updatedEmailConfirmationToken = EmailConfirmationTokenBuilder.WithAlreadyExpiresAtUtc().Build();
        await ServiceScope.UpdateEmailConfirmationTokenAsync(updatedEmailConfirmationToken, CancellationToken);

        // Assert
        await Sender.ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdatedUser_WhenRequestIsValid()
    {
        // Act
        await Sender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldUpdatedUser_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(_request);
    }

    [Theory]
    [EmailConfirmationTokenValueDifferentCaseData]
    public async Task SendAsync_ShouldUpdatedUser_WhenRequestAndValueAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithValue(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(_request);
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteEmailConfirmationToken_WhenRequestIsValid()
    {
        // Act
        await Sender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.EmailConfirmationTokens.ShouldBeEmpty();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeleteEmailConfirmationToken_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.EmailConfirmationTokens.ShouldBeEmpty();
    }

    [Theory]
    [EmailConfirmationTokenValueDifferentCaseData]
    public async Task SendAsync_ShouldDeleteEmailConfirmationToken_WhenRequestAndValueAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithValue(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.EmailConfirmationTokens.ShouldBeEmpty();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishEmailConfirmationTokenUpdatedEvents_WhenRequestIsValid()
    {
        // Act
        await Sender.SendAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(User.EmailConfirmationTokens, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishEmailConfirmationTokenUpdatedEvents_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(User.EmailConfirmationTokens, CancellationToken);
    }

    [Theory]
    [EmailConfirmationTokenValueDifferentCaseData]
    public async Task SendAsync_ShouldPublishEmailConfirmationTokenUpdatedEvents_WhenRequestAndValueAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithValue(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(User.EmailConfirmationTokens, CancellationToken);
    }
}
