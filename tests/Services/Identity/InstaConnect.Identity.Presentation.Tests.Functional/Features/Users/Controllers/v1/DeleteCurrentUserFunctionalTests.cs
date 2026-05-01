namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Controllers.v1;

public class DeleteCurrentUserFunctionalTests : BaseUserPresentationCommandFunctionalTest
{
	private readonly DeleteCurrentUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteCurrentUserApiRequestBuilder _requestBuilder;
	private readonly DeleteCurrentUserApiRequest _request;

	public DeleteCurrentUserFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddEmailConfirmationTokenRangeAsync(User.EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await Client.DeleteCurrentUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task DeleteCurrentAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.DeleteCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.DeleteCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await Client.DeleteCurrentStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await Client.DeleteCurrentProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Client.DeleteCurrentStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldHaveNoContentStatusCode_WhenRequestAndIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.DeleteCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldDeleteUser_WhenRequestIsValid()
	{
		// Act
		await Client.DeleteCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldDeleteUser_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Client.DeleteCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldPublishUserDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await Client.DeleteCurrentAsync(_request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserDeletedAsync(User, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldPublishUserDeletedEvent_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Client.DeleteCurrentAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserDeletedAsync(User, CancellationToken);
	}
}
