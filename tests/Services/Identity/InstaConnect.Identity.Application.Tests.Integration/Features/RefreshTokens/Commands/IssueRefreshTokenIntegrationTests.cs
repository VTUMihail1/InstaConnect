namespace InstaConnect.Identity.Application.Tests.Integration.Features.RefreshTokens.Commands;

public class IssueRefreshTokenIntegrationTests : BaseRefreshTokenApplicationCommandIntegrationTest
{
	private readonly IssueRefreshTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly IssueRefreshTokenCommandRequestBuilder _requestBuilder;
	private readonly IssueRefreshTokenCommandRequest _request;

	public IssueRefreshTokenIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, Password);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddClaimRangeAsync(User.UserClaims, CancellationToken);
	}

	[Theory]
	[UserNameNullWithMessageData]
	[UserNameEmptyWithMessageData]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForNameAsync(messageTransformer, request, CancellationToken);
	}

	[Theory]
	[UserPasswordNullWithMessageData]
	[UserPasswordEmptyWithMessageData]
	[UserPasswordTooShortWithMessageData]
	[UserPasswordTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForPasswordAsync(messageTransformer, request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserInvalidDetailsException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserInvalidDetailsExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserInvalidDetailsException_WhenPasswordDoesNotMatch()
	{
		// Arrange
		var updatedUser = UserBuilder.WithPasswordHash(PasswordHasher.Hash(NewPassword)).Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserInvalidDetailsExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNameEmailNotConfirmedException_WhenEmailIsNotConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNameEmailNotConfirmedExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, refreshToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, refreshToken);
	}

	[Fact]
	public async Task SendAsync_ShouldAddRefreshToken_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(_request, PasswordHasher);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldAddRefreshToken_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(_request, PasswordHasher);
	}
}
