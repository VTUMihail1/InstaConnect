namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Controllers.v1;

public class AddFollowFunctionalTests : BaseFollowPresentationCommandFunctionalTest
{
    private readonly AddFollowApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddFollowApiRequestBuilder _requestBuilder;
    private readonly AddFollowApiRequest _request;

    public AddFollowFunctionalTests(FollowsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Follower, Following);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(Follower, CancellationToken);
        await ServiceScope.AddUserAsync(Following, CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.AddFollowStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowerIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenFollowerIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForFollowerId(messageTransformer, request);
    }

    [Theory]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowingIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenFollowingIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForFollowingId(messageTransformer, request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenFollowerIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(Follower, CancellationToken);

        // Act
        var response = await HttpClient.AddFollowStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveFollowerNotFoundProblemDetails_WhenFollowerIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(Follower, CancellationToken);

        // Act
        var response = await HttpClient.AddFollowProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyFollowerNotFound(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenFollowingIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(Following, CancellationToken);

        // Act
        var response = await HttpClient.AddFollowStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveFollowingNotFoundProblemDetails_WhenFollowingIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(Following, CancellationToken);

        // Act
        var response = await HttpClient.AddFollowProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyFollowingNotFound(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddFollowAsync(Follow, CancellationToken);

        // Act
        var response = await HttpClient.AddFollowStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowAlreadyExistsAndFollowerIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddFollowAsync(Follow, CancellationToken);
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowAlreadyExistsAndFollowingIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddFollowAsync(Follow, CancellationToken);
        var request = _requestBuilder.WithFollowingId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveFollowAlreadyExistsProblemDetails_WhenFollowAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddFollowAsync(Follow, CancellationToken);

        // Act
        var response = await HttpClient.AddFollowProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyFollowAlreadyExists(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveFollowAlreadyExistsProblemDetails_WhenFollowAlreadyExistsAndFollowerIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddFollowAsync(Follow, CancellationToken);
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyFollowAlreadyExists(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveFollowAlreadyExistsProblemDetails_WhenFollowAlreadyExistsAndFollowingIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddFollowAsync(Follow, CancellationToken);
        var request = _requestBuilder.WithFollowingId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyFollowAlreadyExists(request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddFollowStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndFollowerIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndFollowingIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddFollowAsync(_request, CancellationToken);
        var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(follow, _request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndFollowerIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowAsync(request, CancellationToken);
        var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(follow, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndFollowingIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowAsync(request, CancellationToken);
        var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(follow, request);
    }

    [Fact]
    public async Task AddAsync_ShouldAddFollow_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddFollowAsync(_request, CancellationToken);
        var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

        // Assert
        follow.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldAddFollow_WhenRequestAndFollowerIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowAsync(request, CancellationToken);
        var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

        // Assert
        follow.ShouldSatisfy(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldAddFollow_WhenRequestAndFollowingIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowAsync(request, CancellationToken);
        var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

        // Assert
        follow.ShouldSatisfy(request);
    }

    [Fact]
    public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddFollowAsync(_request, CancellationToken);
        var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedFollowAddedAsync(follow, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenRequestAndFollowerIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowAsync(request, CancellationToken);
        var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedFollowAddedAsync(follow, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenRequestAndFollowingIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingId(transformer).Build();

        // Act
        var response = await HttpClient.AddFollowAsync(request, CancellationToken);
        var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedFollowAddedAsync(follow, CancellationToken);
    }
}
