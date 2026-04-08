using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.RefreshTokens.Controllers.v1;

public class IssueRefreshTokenFunctionalTests : BaseRefreshTokenPresentationCommandFunctionalTest
{
    private readonly IssueRefreshTokenApiRequestBuilderFactory _requestBuilderFactory;
    private readonly IssueRefreshTokenApiRequestBuilder _requestBuilder;
    private readonly IssueRefreshTokenApiRequest _request;

    public IssueRefreshTokenFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User, Password);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddUserClaimRangeAsync(User.UserClaims, CancellationToken);
    }

    [Theory]
    [UserNameTooShortData]
    [UserNameTooLongData]
    public async Task IssueAsync_ShouldHaveBadRequestStatusCode_WhenNameIsInvalid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await HttpClient.IssueRefreshTokenStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserNameTooShortWithMessageData]
    [UserNameTooLongWithMessageData]
    public async Task IssueAsync_ShouldHaveBadRequestProblemDetails_WhenNameIsInvalid(
        IStringTransformer transformer,
        IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await HttpClient.IssueRefreshTokenProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForName(messageTransformer, request);
    }

    [Theory]
    [UserPasswordNullData]
    [UserPasswordEmptyData]
    [UserPasswordTooShortData]
    [UserPasswordTooLongData]
    public async Task IssueAsync_ShouldHaveBadRequestStatusCode_WhenPasswordIsInvalid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPassword(transformer).Build();

        // Act
        var response = await HttpClient.IssueRefreshTokenStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserPasswordNullWithMessageData]
    [UserPasswordEmptyWithMessageData]
    [UserPasswordTooShortWithMessageData]
    [UserPasswordTooLongWithMessageData]
    public async Task IssueAsync_ShouldHaveBadRequestProblemDetails_WhenPasswordIsInvalid(
        IStringTransformer transformer,
        IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPassword(transformer).Build();

        // Act
        var response = await HttpClient.IssueRefreshTokenProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPassword(messageTransformer, request);
    }

    [Fact]
    public async Task IssueAsync_ShouldHaveBadRequestStatusCode_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.IssueRefreshTokenStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Fact]
    public async Task IssueAsync_ShouldHaveUserInvalidDetailsProblemDetails_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.IssueRefreshTokenProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserInvalidDetails(_request);
    }

    [Fact]
    public async Task IssueAsync_ShouldHaveBadRequestStatusCode_WhenPasswordDoesNotMatch()
    {
        // Arrange
        var updatedUser = UserBuilder.WithPasswordHash(PasswordHasher.Hash(NewPassword)).Build();
        await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

        // Act
        var response = await HttpClient.IssueRefreshTokenStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Fact]
    public async Task IssueAsync_ShouldHaveUserInvalidDetailsProblemDetails_WhenPasswordDoesNotMatch()
    {
        // Arrange
        var updatedUser = UserBuilder.WithPasswordHash(PasswordHasher.Hash(NewPassword)).Build();
        await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

        // Act
        var response = await HttpClient.IssueRefreshTokenProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserInvalidDetails(_request);
    }

    [Fact]
    public async Task IssueAsync_ShouldHaveBadRequestStatusCode_WhenEmailIsNotConfirmed()
    {
        // Arrange
        var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
        await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

        // Act
        var response = await HttpClient.IssueRefreshTokenStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Fact]
    public async Task IssueAsync_ShouldHaveUserNameEmailNotConfirmedProblemDetails_WhenEmailIsNotConfirmed()
    {
        // Arrange
        var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
        await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

        // Act
        var response = await HttpClient.IssueRefreshTokenProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNameEmailNotConfirmed(_request);
    }

    [Fact]
    public async Task IssueAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.IssueRefreshTokenStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task IssueAsync_ShouldHaveOkStatusCode_WhenNameIsValid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await HttpClient.IssueRefreshTokenStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task IssueAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.IssueRefreshTokenAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_request);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task IssueAsync_ShouldReturnResponse_WhenNameIsValid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await HttpClient.IssueRefreshTokenAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(request);
    }

    [Fact]
    public async Task IssueAsync_ShouldAddRefreshToken_WhenRequestIsValid()
    {
        // Act
        await HttpClient.IssueRefreshTokenAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.RefreshTokens.ShouldNotBeEmpty();
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task IssueAsync_ShouldIssueRefreshToken_WhenNameIsValid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        await HttpClient.IssueRefreshTokenAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.RefreshTokens.ShouldNotBeEmpty();
    }

    [Fact]
    public async Task IssueAsync_ShouldReturnCookies_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.IssueRefreshTokenResponseCookiesAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(_request, user);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task IssueAsync_ShouldReturnCookies_WhenNameIsValid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await HttpClient.IssueRefreshTokenResponseCookiesAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(request, user);
    }
}
