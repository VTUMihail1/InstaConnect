using InstaConnect.Common.Events.Features.Tokens.Models;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.UserClaims.Controllers.v1;

public class DeleteUserClaimFunctionalTests : BaseUserClaimPresentationCommandFunctionalTest
{
    private readonly DeleteUserClaimApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteUserClaimApiRequestBuilder _requestBuilder;
    private readonly DeleteUserClaimApiRequest _request;

    public DeleteUserClaimFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(UserClaim);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddUserClaimAsync(UserClaim, CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.DeleteUserClaimStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnForbiddenStatusCode_WhenRequestIsForbidden()
    {
        // Act
        var response = await HttpClient.DeleteUserClaimStatusCodeForbiddenAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeForbidden();
    }

    [Theory]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.DeleteUserClaimStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer,
        IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.DeleteUserClaimProblemDetailsAsync(request, CancellationToken);

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
        var response = await HttpClient.DeleteUserClaimStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.DeleteUserClaimProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForClaim(messageTransformer, request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.DeleteUserClaimStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.DeleteUserClaimProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNotFound(_request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenUserClaimNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserClaimAsync(UserClaim, CancellationToken);

        // Act
        var response = await HttpClient.DeleteUserClaimStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveUserClaimNotFoundProblemDetails_WhenUserClaimNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserClaimAsync(UserClaim, CancellationToken);

        // Act
        var response = await HttpClient.DeleteUserClaimProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserClaimNotFound(_request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.DeleteUserClaimStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.DeleteUserClaimStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteUserClaim_WhenRequestIsValid()
    {
        // Act
        await HttpClient.DeleteUserClaimAsync(_request, CancellationToken);
        var userClaim = await ServiceScope.GetUserClaimByIdAsync(UserClaim.Id, CancellationToken);

        // Assert
        userClaim.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeleteUserClaim_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await HttpClient.DeleteUserClaimAsync(request, CancellationToken);
        var userClaim = await ServiceScope.GetUserClaimByIdAsync(UserClaim.Id, CancellationToken);

        // Assert
        userClaim.ShouldBeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldPublishUserClaimDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await HttpClient.DeleteUserClaimAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedUserClaimDeletedAsync(UserClaim, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishUserClaimDeletedEvent_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await HttpClient.DeleteUserClaimAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedUserClaimDeletedAsync(UserClaim, CancellationToken);
    }
}
