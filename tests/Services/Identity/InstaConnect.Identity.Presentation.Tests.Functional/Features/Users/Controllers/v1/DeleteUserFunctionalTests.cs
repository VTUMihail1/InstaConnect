namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Controllers.v1;

public class DeleteUserFunctionalTests : BaseUserPresentationCommandFunctionalTest
{
	private readonly DeleteUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteUserApiRequestBuilder _requestBuilder;
	private readonly DeleteUserApiRequest _request;

	public DeleteUserFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
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
	public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await Client.DeleteUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Fact]
	public async Task DeleteAsync_ShouldReturnForbiddenStatusCode_WhenRequestIsForbidden()
	{
		// Act
		var response = await Client.DeleteForbiddenStatusCodeAsync(_request, CancellationToken);

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
		var response = await Client.DeleteStatusCodeAsync(request, CancellationToken);

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
		var response = await Client.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await Client.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await Client.DeleteProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Client.DeleteStatusCodeAsync(_request, CancellationToken);

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
		var response = await Client.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUser_WhenRequestIsValid()
	{
		// Act
		await Client.DeleteAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUser_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Client.DeleteAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishUserDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await Client.DeleteAsync(_request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserDeletedAsync(User, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishUserDeletedEvent_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Client.DeleteAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserDeletedAsync(User, CancellationToken);
	}
}
