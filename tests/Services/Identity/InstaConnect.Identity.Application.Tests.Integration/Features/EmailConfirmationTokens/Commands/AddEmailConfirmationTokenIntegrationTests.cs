namespace InstaConnect.Identity.Application.Tests.Integration.Features.EmailConfirmationTokens.Commands;

public class AddEmailConfirmationTokenIntegrationTests : BaseEmailConfirmationTokenApplicationCommandIntegrationTest
{
	private readonly AddEmailConfirmationTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddEmailConfirmationTokenCommandRequestBuilder _requestBuilder;
	private readonly AddEmailConfirmationTokenCommandRequest _request;

	public AddEmailConfirmationTokenIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
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

	[Fact]
	public async Task SendAsync_ShouldThrowUserNameNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNameNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNameEmailAlreadyConfirmedException_WhenEmailIsConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithConfirmedEmail().Build();
		await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldAddEmailConfirmationToken_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldNotBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldAddEmailConfirmationToken_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldNotBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenAddedRangeAsync(user, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenAddedRangeAsync(user, CancellationToken);
	}
}
