using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.RefreshTokens.Controllers.v1;

public class RotateRefreshTokenFunctionalTests : BaseRefreshTokenPresentationCommandFunctionalTest
{
	private readonly RotateRefreshTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly RotateRefreshTokenApiRequestBuilder _requestBuilder;
	private readonly RotateRefreshTokenApiRequest _request;

	public RotateRefreshTokenFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(RefreshToken);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddUserClaimRangeAsync(User.UserClaims, CancellationToken);
		await ServiceScope.AddRefreshTokenAsync(RefreshToken, CancellationToken);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task RotateAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.RotateRefreshTokenStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task RotateAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.RotateRefreshTokenProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
	}

	[Theory]
	[RefreshTokenValueNullData]
	[RefreshTokenValueEmptyData]
	[RefreshTokenValueTooShortData]
	[RefreshTokenValueTooLongData]
	public async Task RotateAsync_ShouldHaveBadRequestStatusCode_WhenValueIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await HttpClient.RotateRefreshTokenStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[RefreshTokenValueNullWithMessageData]
	[RefreshTokenValueEmptyWithMessageData]
	[RefreshTokenValueTooShortWithMessageData]
	[RefreshTokenValueTooLongWithMessageData]
	public async Task RotateAsync_ShouldHaveBadRequestProblemDetails_WhenValueIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await HttpClient.RotateRefreshTokenProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForValue(messageTransformer, request);
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await HttpClient.RotateRefreshTokenStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await HttpClient.RotateRefreshTokenProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveBadRequestStatusCode_WhenEmailIsNotConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
		await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

		// Act
		var response = await HttpClient.RotateRefreshTokenStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveUserEmailNotConfirmedProblemDetails_WhenEmailIsNotConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
		await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

		// Act
		var response = await HttpClient.RotateRefreshTokenProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserEmailNotConfirmed(_request);
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveNotFoundStatusCode_WhenRefreshTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteRefreshTokenAsync(RefreshToken, CancellationToken);

		// Act
		var response = await HttpClient.RotateRefreshTokenStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveRefreshTokenNotFoundProblemDetails_WhenRefreshTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteRefreshTokenAsync(RefreshToken, CancellationToken);

		// Act
		var response = await HttpClient.RotateRefreshTokenProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyRefreshTokenNotFound(_request);
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveBadRequestStatusCode_WhenRefreshTokenHasExpired()
	{
		// Arrange
		var updatedRefreshToken = RefreshTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateRefreshTokenAsync(updatedRefreshToken, CancellationToken);

		// Act
		var response = await HttpClient.RotateRefreshTokenStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveRefreshTokenExpiredProblemDetails_WhenRefreshTokenHasExpired()
	{
		// Arrange
		var updatedRefreshToken = RefreshTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateRefreshTokenAsync(updatedRefreshToken, CancellationToken);

		// Act
		var response = await HttpClient.RotateRefreshTokenProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyRefreshTokenExpired(_request);
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.RotateRefreshTokenStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldHaveOkStatusCode_WhenIdIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.RotateRefreshTokenStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldHaveOkStatusCode_WhenValueIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await HttpClient.RotateRefreshTokenStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task RotateAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.RotateRefreshTokenAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldReturnResponse_WhenIdIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.RotateRefreshTokenAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldReturnResponse_WhenValueIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await HttpClient.RotateRefreshTokenAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request);
	}

	[Fact]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenRequestIsValid()
	{
		// Act
		await HttpClient.RotateRefreshTokenAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldNotBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldRotateRefreshToken_WhenIdIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await HttpClient.RotateRefreshTokenAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldNotBeEmpty();
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldRotateRefreshToken_WhenValueIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await HttpClient.RotateRefreshTokenAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldNotBeEmpty();
	}

	[Fact]
	public async Task RotateAsync_ShouldReturnCookies_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.RotateRefreshTokenResponseCookiesAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, user);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldReturnCookies_WhenIdIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.RotateRefreshTokenResponseCookiesAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldReturnCookies_WhenValueIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await HttpClient.RotateRefreshTokenResponseCookiesAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}
}
