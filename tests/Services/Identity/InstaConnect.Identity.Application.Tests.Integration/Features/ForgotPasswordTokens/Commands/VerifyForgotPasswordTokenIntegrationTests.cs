namespace InstaConnect.Identity.Application.Tests.Integration.Features.ForgotPasswordTokens.Commands;

public class VerifyForgotPasswordTokenIntegrationTests : BaseForgotPasswordTokenApplicationCommandIntegrationTest
{
	private const string PasswordPropertyName = nameof(VerifyForgotPasswordTokenCommandRequest.Password);

	private readonly VerifyForgotPasswordTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly VerifyForgotPasswordTokenCommandRequestBuilder _requestBuilder;
	private readonly VerifyForgotPasswordTokenCommandRequest _request;

	public VerifyForgotPasswordTokenIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ForgotPasswordToken);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddForgotPasswordTokenRangeAsync(User.ForgotPasswordTokens, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(messageTransformer, request, CancellationToken);
	}

	[Theory]
	[ForgotPasswordTokenValueNullWithMessageData]
	[ForgotPasswordTokenValueEmptyWithMessageData]
	[ForgotPasswordTokenValueTooShortWithMessageData]
	[ForgotPasswordTokenValueTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenValueIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForValueAsync(messageTransformer, request, CancellationToken);
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

	[Theory]
	[UserConfirmPasswordNotEqualWithMessageData(PasswordPropertyName)]
	public async Task SendAsync_ShouldThrowValidationException_WhenConfirmPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithConfirmPassword(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForConfirmPasswordAsync(messageTransformer, request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowForgotPasswordTokenNotFoundException_WhenForgotPasswordTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteForgotPasswordTokenAsync(ForgotPasswordToken, CancellationToken);

		// Assert
		await Sender.ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowForgotPasswordExpiredException_WhenForgotPasswordTokenHasExpired()
	{
		// Arrange
		var updatedForgotPasswordToken = ForgotPasswordTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateForgotPasswordTokenAsync(updatedForgotPasswordToken, CancellationToken);

		// Assert
		await Sender.ShouldThrowForgotPasswordTokenExpiredExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldUpdatedUser_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request, PasswordHasher);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldUpdatedUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request, PasswordHasher);
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task SendAsync_ShouldUpdatedUser_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request, PasswordHasher);
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteForgotPasswordToken_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteForgotPasswordToken_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldBeEmpty();
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task SendAsync_ShouldDeleteForgotPasswordToken_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldPublishForgotPasswordTokenDeletedEvents_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedForgotPasswordTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishForgotPasswordTokenDeletedEvents_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedForgotPasswordTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task SendAsync_ShouldPublishForgotPasswordTokenDeletedEvents_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedForgotPasswordTokenDeletedRangeAsync(User, CancellationToken);
	}
}
