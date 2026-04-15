namespace InstaConnect.Identity.Application.Tests.Integration.Features.ForgotPasswordTokens.Commands;

public class AddForgotPasswordTokenIntegrationTests : BaseForgotPasswordTokenApplicationCommandIntegrationTest
{
    private readonly AddForgotPasswordTokenCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddForgotPasswordTokenCommandRequestBuilder _requestBuilder;
    private readonly AddForgotPasswordTokenCommandRequest _request;

    public AddForgotPasswordTokenIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
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

    [Fact]
    public async Task SendAsync_ShouldThrowUserNameNotFoundException_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Assert
        await Sender.ShouldThrowUserNameNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldAddForgotPasswordToken_WhenRequestIsValid()
    {
        // Act
        await Sender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ForgotPasswordTokens.ShouldNotBeEmpty();
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldAddForgotPasswordToken_WhenRequestAndNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ForgotPasswordTokens.ShouldNotBeEmpty();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishForgotPasswordTokenAddedEvent_WhenRequestIsValid()
    {
        // Act
        await Sender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedForgotPasswordTokenAddedRangeAsync(user, CancellationToken);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldPublishForgotPasswordTokenAddedEvent_WhenRequestAndNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedForgotPasswordTokenAddedRangeAsync(user, CancellationToken);
    }
}
