using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Controllers.v1;

public class GetCurrentUserByIdFunctionalTests : BaseUserPresentationQueryFunctionalTest
{
    private readonly GetCurrentUserByIdApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetCurrentUserByIdApiRequestBuilder _requestBuilder;
    private readonly GetCurrentUserByIdApiRequest _request;

    public GetCurrentUserByIdFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
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
    public async Task GetCurrentByIdAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.GetCurrentUserByIdStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Theory]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task GetCurrentByIdAsync_ShouldHaveBadRequestStatusCode_WhenCurrentIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentId(transformer).Build();

        // Act
        var response = await HttpClient.GetCurrentUserByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task GetCurrentByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentId(transformer).Build();

        // Act
        var response = await HttpClient.GetCurrentUserByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForCurrentId(messageTransformer, request);
    }

    [Fact]
    public async Task GetCurrentByIdAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.GetCurrentUserByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetCurrentByIdAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.GetCurrentUserByIdProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNotFound(_request);
    }

    [Fact]
    public async Task GetCurrentByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetCurrentUserByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetCurrentByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentId(transformer).Build();

        // Act
        var response = await HttpClient.GetCurrentUserByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetCurrentByIdAsync_ShouldHaveResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetCurrentUserByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, _request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetCurrentByIdAsync_ShouldHaveResponse_WhenRequestAndCurrentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentId(transformer).Build();

        // Act
        var response = await HttpClient.GetCurrentUserByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, request);
    }

    [Fact]
    public async Task GetCurrentByIdAsync_ShouldCacheResponse_WhenRequestIsValid()
    {
        // Act
        await HttpClient.GetCurrentUserByIdAsync(_request, CancellationToken);
        var response = await ServiceScope.GetResponseFromCache(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, _request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetCurrentByIdAsync_ShouldCacheResponse_WhenRequestAndCurrentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentId(transformer).Build();

        // Act
        await HttpClient.GetCurrentUserByIdAsync(request, CancellationToken);
        var response = await ServiceScope.GetResponseFromCache(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, request);
    }
}
