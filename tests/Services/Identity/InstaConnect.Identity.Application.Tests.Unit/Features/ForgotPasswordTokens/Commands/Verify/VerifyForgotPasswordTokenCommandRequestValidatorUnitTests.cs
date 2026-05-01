namespace InstaConnect.Identity.Application.Tests.Unit.Features.ForgotPasswordTokens.Commands.Verify;

public class VerifyForgotPasswordTokenCommandRequestValidatorUnitTests : BaseForgotPasswordTokenApplicationCommandUnitTest
{
	private const string PasswordPropertyName = nameof(VerifyForgotPasswordTokenCommandRequest.Password);

	private readonly VerifyForgotPasswordTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly VerifyForgotPasswordTokenCommandRequestBuilder _requestBuilder;
	private readonly VerifyForgotPasswordTokenCommandRequest _request;

	private readonly VerifyForgotPasswordTokenCommandRequestValidator _requestValidator;

	public VerifyForgotPasswordTokenCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ForgotPasswordToken);
		_request = _requestBuilder.Build();

		_requestValidator = new();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var result = _requestValidator.TestValidate(request);

		// Assert
		result.ShouldHaveValidationErrorForId(messageTransformer, request);
	}

	[Theory]
	[ForgotPasswordTokenValueNullWithMessageData]
	[ForgotPasswordTokenValueEmptyWithMessageData]
	[ForgotPasswordTokenValueTooShortWithMessageData]
	[ForgotPasswordTokenValueTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenValueIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var result = _requestValidator.TestValidate(request);

		// Assert
		result.ShouldHaveValidationErrorForValue(messageTransformer, request);
	}

	[Theory]
	[UserPasswordNullWithMessageData]
	[UserPasswordEmptyWithMessageData]
	[UserPasswordTooShortWithMessageData]
	[UserPasswordTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Act
		var result = _requestValidator.TestValidate(request);

		// Assert
		result.ShouldHaveValidationErrorForPassword(messageTransformer, request);
	}

	[Theory]
	[UserConfirmPasswordNotEqualWithMessageData(PasswordPropertyName)]
	public void TestValidate_ShouldHaveAnError_WhenConfirmPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithConfirmPassword(transformer).Build();

		// Act
		var result = _requestValidator.TestValidate(request);

		// Assert
		result.ShouldHaveValidationErrorForConfirmPassword(messageTransformer, request);
	}

	[Fact]
	public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestIsValid()
	{
		// Act
		var result = _requestValidator.TestValidate(_request);

		// Assert
		result.ShouldNotHaveAnyValidationErrorProperties();
	}
}
