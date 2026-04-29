using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Controllers.v1;

public class AddUserFunctionalTests : BaseUserPresentationCommandFunctionalTest
{
	private const string PasswordPropertyName = nameof(AddUserApiForm.Password);

	private readonly AddUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserApiRequestBuilder _requestBuilder;
	private readonly AddUserApiRequest _request;

	public AddUserFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create();
		_request = _requestBuilder.Build();
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameTooShortData]
	[UserNameTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenNameIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await HttpClient.AddUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameNullWithMessageData]
	[UserNameEmptyWithMessageData]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await HttpClient.AddUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForName(messageTransformer, request);
	}

	[Theory]
	[UserFirstNameNullData]
	[UserFirstNameEmptyData]
	[UserFirstNameTooShortData]
	[UserFirstNameTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFirstNameIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await HttpClient.AddUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserFirstNameNullWithMessageData]
	[UserFirstNameEmptyWithMessageData]
	[UserFirstNameTooShortWithMessageData]
	[UserFirstNameTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenFirstNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await HttpClient.AddUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFirstName(messageTransformer, request);
	}

	[Theory]
	[UserLastNameNullData]
	[UserLastNameEmptyData]
	[UserLastNameTooShortData]
	[UserLastNameTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenLastNameIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = await HttpClient.AddUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserLastNameNullWithMessageData]
	[UserLastNameEmptyWithMessageData]
	[UserLastNameTooShortWithMessageData]
	[UserLastNameTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenLastNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = await HttpClient.AddUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForLastName(messageTransformer, request);
	}

	[Theory]
	[UserEmailNullData]
	[UserEmailEmptyData]
	[UserEmailTooShortData]
	[UserEmailTooLongData]
	[UserEmailInvalidData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenEmailIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await HttpClient.AddUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserEmailNullWithMessageData]
	[UserEmailEmptyWithMessageData]
	[UserEmailTooShortWithMessageData]
	[UserEmailTooLongWithMessageData]
	[UserEmailInvalidWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenEmailIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await HttpClient.AddUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForEmail(messageTransformer, request);
	}

	[Theory]
	[UserPasswordNullData]
	[UserPasswordEmptyData]
	[UserPasswordTooShortData]
	[UserPasswordTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPasswordIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Act
		var response = await HttpClient.AddUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserPasswordNullWithMessageData]
	[UserPasswordEmptyWithMessageData]
	[UserPasswordTooShortWithMessageData]
	[UserPasswordTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenPasswordIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Act
		var response = await HttpClient.AddUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPassword(messageTransformer, request);
	}

	[Theory]
	[UserConfirmPasswordNotEqualData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenConfirmPasswordIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithConfirmPassword(transformer).Build();

		// Act
		var response = await HttpClient.AddUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserConfirmPasswordNotEqualWithMessageData(PasswordPropertyName)]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenConfirmPasswordIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithConfirmPassword(transformer).Build();

		// Act
		var response = await HttpClient.AddUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForConfirmPassword(messageTransformer, request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenEmailAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await HttpClient.AddUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenEmailAlreadyExistsAndCaseDiffers(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await HttpClient.AddUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveUserEmailAlreadyTakenProblemDetails_WhenEmailAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await HttpClient.AddUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserEmailAlreadyTaken(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task AddAsync_ShouldHaveUserEmailAlreadyTakenProblemDetails_WhenEmailAlreadyExistsAndCaseDiffers(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await HttpClient.AddUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserEmailAlreadyTaken(request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserNameAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await HttpClient.AddUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserNameAlreadyExistsAndCaseDiffers(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await HttpClient.AddUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveUserNameAlreadyTakenProblemDetails_WhenUserNameAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await HttpClient.AddUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNameAlreadyTaken(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldHaveUserNameAlreadyTakenProblemDetails_WhenUserNameAlreadyExistsAndCaseDiffers(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await HttpClient.AddUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNameAlreadyTaken(request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddUserStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenProfileImageIsValid(IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await HttpClient.AddUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddUserAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, _request);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldReturnResponse_WhenProfileImageIsValid(IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await HttpClient.AddUserAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Fact]
	public async Task AddAsync_ShouldAddUser_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddUserAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request, PasswordHasher);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldAddUser_WhenProfileImageIsValid(IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await HttpClient.AddUserAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request, PasswordHasher);
	}

	[Fact]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddUserAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldNotBeEmpty();
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenProfileImageIsValid(IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await HttpClient.AddUserAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldNotBeEmpty();
	}

	[Fact]
	public async Task AddAsync_ShouldPublishUserAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddUserAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserAddedAsync(user, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldPublishUserAddedEvent_WhenRequestAndProfileImageAreValid(IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await HttpClient.AddUserAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserAddedAsync(user, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddUserAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenAddedRangeAsync(user, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestAndProfileImageAreValid(IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await HttpClient.AddUserAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenAddedRangeAsync(user, CancellationToken);
	}
}
