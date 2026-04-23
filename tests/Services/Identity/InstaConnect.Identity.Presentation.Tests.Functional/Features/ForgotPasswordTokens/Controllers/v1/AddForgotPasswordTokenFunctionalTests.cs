using InstaConnect.Identity.Tests.Features.Common.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.ForgotPasswordTokens.Controllers.v1;

public class AddForgotPasswordTokenFunctionalTests : BaseForgotPasswordTokenPresentationCommandFunctionalTest
{
    private readonly AddForgotPasswordTokenApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddForgotPasswordTokenApiRequestBuilder _requestBuilder;
    private readonly AddForgotPasswordTokenApiRequest _request;

    public AddForgotPasswordTokenFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddUserClaimAsync(UserClaim, CancellationToken);
    }

    [Theory]
    [UserNameTooShortData]
    [UserNameTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenNameIsInvalid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await HttpClient.AddForgotPasswordTokenStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserNameTooShortWithMessageData]
    [UserNameTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenNameIsInvalid(
        IStringTransformer transformer,
        IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await HttpClient.AddForgotPasswordTokenProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForName(messageTransformer, request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.AddForgotPasswordTokenStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveUserNameNotFoundProblemDetails_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.AddForgotPasswordTokenProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNameNotFound(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddForgotPasswordTokenStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenNameIsValid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await HttpClient.AddForgotPasswordTokenStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Fact]
    public async Task AddAsync_ShouldAddForgotPasswordToken_WhenRequestIsValid()
    {
        // Act
        await HttpClient.AddForgotPasswordTokenAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ForgotPasswordTokens.ShouldNotBeEmpty();
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task AddAsync_ShouldAddForgotPasswordToken_WhenNameIsValid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        await HttpClient.AddForgotPasswordTokenAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ForgotPasswordTokens.ShouldNotBeEmpty();
    }

    [Fact]
    public async Task AddAsync_ShouldPublishForgotPasswordTokenAddedEvent_WhenRequestIsValid()
    {
        // Act
        await HttpClient.AddForgotPasswordTokenAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedForgotPasswordTokenAddedRangeAsync(user, CancellationToken);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task AddAsync_ShouldPublishForgotPasswordTokenAddedEvent_WhenRequestAndNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        await HttpClient.AddForgotPasswordTokenAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedForgotPasswordTokenAddedRangeAsync(user, CancellationToken);
    }
}
