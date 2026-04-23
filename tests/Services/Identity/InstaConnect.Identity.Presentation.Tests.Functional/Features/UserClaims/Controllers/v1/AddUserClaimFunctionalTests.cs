using InstaConnect.Common.Events.Models;
using InstaConnect.Identity.Tests.Features.Common.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.UserClaims.Controllers.v1;

public class AddUserClaimFunctionalTests : BaseUserClaimPresentationCommandFunctionalTest
{
    private readonly AddUserClaimApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddUserClaimApiRequestBuilder _requestBuilder;
    private readonly AddUserClaimApiRequest _request;

    public AddUserClaimFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
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

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.AddUserClaimStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnForbiddenStatusCode_WhenRequestIsForbidden()
    {
        // Act
        var response = await HttpClient.AddUserClaimStatusCodeForbiddenAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeForbidden();
    }

    [Theory]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddUserClaimStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer,
        IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddUserClaimProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
    }

    [Theory]
    [UserClaimClaimEmptyData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenClaimIsInvalid(IEnumTransformer<ApplicationClaims> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithClaim(transformer).Build();

        // Act
        var response = await HttpClient.AddUserClaimStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserClaimClaimEmptyWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenClaimIsInvalid(
        IEnumTransformer<ApplicationClaims> transformer,
        IEnumMessageTransformer<ApplicationClaims> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithClaim(transformer).Build();

        // Act
        var response = await HttpClient.AddUserClaimProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForClaim(messageTransformer, request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.AddUserClaimStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.AddUserClaimProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNotFound(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserClaimAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddUserClaimAsync(UserClaim, CancellationToken);

        // Act
        var response = await HttpClient.AddUserClaimStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserClaimAlreadyExistsAndCaseDiffers(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddUserClaimAsync(UserClaim, CancellationToken);
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddUserClaimStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveUserClaimAlreadyTakenProblemDetails_WhenUserClaimAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddUserClaimAsync(UserClaim, CancellationToken);

        // Act
        var response = await HttpClient.AddUserClaimProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserClaimAlreadyExists(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveUserClaimAlreadyTakenProblemDetails_WhenUserClaimAlreadyExistsAndCaseDiffers(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddUserClaimAsync(UserClaim, CancellationToken);
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddUserClaimProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserClaimAlreadyExists(request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddUserClaimStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenIdIsValid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddUserClaimStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddUserClaimAsync(_request, CancellationToken);
        var userClaim = await ServiceScope.GetUserClaimByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(userClaim, _request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenIdIsValid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddUserClaimAsync(request, CancellationToken);
        var userClaim = await ServiceScope.GetUserClaimByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(userClaim, request);
    }

    [Fact]
    public async Task AddAsync_ShouldAddUserClaim_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddUserClaimAsync(_request, CancellationToken);
        var userClaim = await ServiceScope.GetUserClaimByIdAsync(response.Response, CancellationToken);

        // Assert
        userClaim.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldAddUserClaim_WhenIdIsValid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddUserClaimAsync(request, CancellationToken);
        var userClaim = await ServiceScope.GetUserClaimByIdAsync(response.Response, CancellationToken);

        // Assert
        userClaim.ShouldSatisfy(request);
    }

    [Fact]
    public async Task AddAsync_ShouldPublishUserClaimAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddUserClaimAsync(_request, CancellationToken);
        var userClaim = await ServiceScope.GetUserClaimByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedUserClaimAddedAsync(userClaim, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishUserClaimAddedEvent_WhenRequestAndIdIsValid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddUserClaimAsync(request, CancellationToken);
        var userClaim = await ServiceScope.GetUserClaimByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedUserClaimAddedAsync(userClaim, CancellationToken);
    }
}
