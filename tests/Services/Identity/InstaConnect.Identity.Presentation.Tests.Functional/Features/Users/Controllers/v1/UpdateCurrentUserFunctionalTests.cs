using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Controllers.v1;

public class UpdateCurrentUserFunctionalTests : BaseUserPresentationCommandFunctionalTest
{
	private readonly UpdateCurrentUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateCurrentUserApiRequestBuilder _requestBuilder;
	private readonly UpdateCurrentUserApiRequest _request;

	public UpdateCurrentUserFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
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
	public async Task UpdateCurrentAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await Client.UpdateCurrentUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameTooShortData]
	[UserNameTooLongData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameNullWithMessageData]
	[UserNameEmptyWithMessageData]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForName(messageTransformer, request);
	}

	[Theory]
	[UserFirstNameNullData]
	[UserFirstNameEmptyData]
	[UserFirstNameTooShortData]
	[UserFirstNameTooLongData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenFirstNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserFirstNameNullWithMessageData]
	[UserFirstNameEmptyWithMessageData]
	[UserFirstNameTooShortWithMessageData]
	[UserFirstNameTooLongWithMessageData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenFirstNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFirstName(messageTransformer, request);
	}

	[Theory]
	[UserLastNameNullData]
	[UserLastNameEmptyData]
	[UserLastNameTooShortData]
	[UserLastNameTooLongData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenLastNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserLastNameNullWithMessageData]
	[UserLastNameEmptyWithMessageData]
	[UserLastNameTooShortWithMessageData]
	[UserLastNameTooLongWithMessageData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenLastNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForLastName(messageTransformer, request);
	}

	[Theory]
	[UserEmailNullData]
	[UserEmailEmptyData]
	[UserEmailTooShortData]
	[UserEmailTooLongData]
	[UserEmailInvalidData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserEmailNullWithMessageData]
	[UserEmailEmptyWithMessageData]
	[UserEmailTooShortWithMessageData]
	[UserEmailTooLongWithMessageData]
	[UserEmailInvalidWithMessageData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenEmailIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForEmail(messageTransformer, request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await Client.UpdateCurrentProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenUserEmailAlreadyTaken()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var request = _requestBuilder.WithEmail(user.Email).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenUserEmailAlreadyTakenAndEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var request = _requestBuilder.WithEmail(user.Email, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveUserEmailAlreadyTakenProblemDetails_WhenUserEmailAlreadyTaken()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var request = _requestBuilder.WithEmail(user.Email).Build();

		// Act
		var response = await Client.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserEmailAlreadyTaken(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveUserEmailAlreadyTakenProblemDetails_WhenEmailIsValidAndAlreadyTaken(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var request = _requestBuilder.WithEmail(user.Email, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserEmailAlreadyTaken(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenUserNameAlreadyTaken()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var request = _requestBuilder.WithName(user.Name).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenUserNameAlreadyTakenAndNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var request = _requestBuilder.WithName(user.Name, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveUserNameAlreadyTakenProblemDetails_WhenUserNameAlreadyTaken()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var request = _requestBuilder.WithName(user.Name).Build();

		// Act
		var response = await Client.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNameAlreadyTaken(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveUserNameAlreadyTakenProblemDetails_WhenNameIsValidAndAlreadyTaken(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var request = _requestBuilder.WithName(user.Name, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNameAlreadyTaken(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Client.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, _request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenRequestIsValid()
	{
		// Act
		var response = await Client.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Client.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenRequestIsValid()
	{
		// Act
		var response = await Client.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldNotDeleteEmailConfirmationTokens_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(User.EmailConfirmationTokens);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldNotDeleteEmailConfirmationTokens_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(User.EmailConfirmationTokens);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Client.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestIsValid()
	{
		// Act
		await Client.UpdateCurrentAsync(_request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Client.UpdateCurrentAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await Client.UpdateCurrentAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		await Client.UpdateCurrentAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		await Client.UpdateCurrentAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldNotPublishEmailConfirmationTokenDeletedEvents_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		await Client.UpdateCurrentAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHaveNotPublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldNotPublishEmailConfirmationTokenDeletedEvents_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await Client.UpdateCurrentAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHaveNotPublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		await Client.UpdateCurrentAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		await Client.UpdateCurrentAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}
}
