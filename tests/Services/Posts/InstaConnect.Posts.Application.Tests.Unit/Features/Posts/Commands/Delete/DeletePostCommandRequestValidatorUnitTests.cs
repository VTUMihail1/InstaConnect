namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Commands.Delete;

public class DeletePostCommandRequestValidatorUnitTests : BasePostApplicationCommandUnitTest
{
	private readonly DeletePostCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeletePostCommandRequestBuilder _requestBuilder;
	private readonly DeletePostCommandRequest _request;

	private readonly DeletePostCommandRequestValidator _requestValidator;

	public DeletePostCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();

		_requestValidator = new();
	}

	[Theory]
	[PostIdNullWithMessageData]
	[PostIdEmptyWithMessageData]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
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
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var result = _requestValidator.TestValidate(request);

		// Assert
		result.ShouldHaveValidationErrorForUserId(messageTransformer, request);
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
