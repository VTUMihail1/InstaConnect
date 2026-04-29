namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Controllers.v1;

public class GetCurrentUserDetailsByIdFunctionalTests : BaseUserPresentationQueryFunctionalTest
{
	private readonly GetCurrentUserDetailsByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetCurrentUserDetailsByIdApiRequestBuilder _requestBuilder;
	private readonly GetCurrentUserDetailsByIdApiRequest _request;

	public GetCurrentUserDetailsByIdFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
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
	public async Task GetCurrentDetailsByIdAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await HttpClient.GetCurrentUserDetailsByIdStatusCodeUnauthorizedAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveBadRequestStatusCode_WhenCurrentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await HttpClient.GetCurrentUserDetailsByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await HttpClient.GetCurrentUserDetailsByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentId(messageTransformer, request);
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await HttpClient.GetCurrentUserDetailsByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await HttpClient.GetCurrentUserDetailsByIdProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.GetCurrentUserDetailsByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await HttpClient.GetCurrentUserDetailsByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveResponse_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.GetCurrentUserDetailsByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, _request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveResponse_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await HttpClient.GetCurrentUserDetailsByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, request);
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldCacheResponse_WhenRequestIsValid()
	{
		// Act
		await HttpClient.GetCurrentUserDetailsByIdAsync(_request, CancellationToken);
		var response = await ServiceScope.GetResponseFromCache(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, _request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetCurrentDetailsByIdAsync_ShouldCacheResponse_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		await HttpClient.GetCurrentUserDetailsByIdAsync(request, CancellationToken);
		var response = await ServiceScope.GetResponseFromCache(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, request);
	}
}
