namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Commands.Delete;

public class DeletePostCommentLikeCommandRequestValidatorUnitTests : BasePostCommentLikeApplicationCommandUnitTest
{
	private readonly DeletePostCommentLikeCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeletePostCommentLikeCommandRequestBuilder _requestBuilder;
	private readonly DeletePostCommentLikeCommandRequest _request;

	private readonly DeletePostCommentLikeCommandRequestValidator _requestValidator;

	public DeletePostCommentLikeCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
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
	[PostCommentIdNullWithMessageData]
	[PostCommentIdEmptyWithMessageData]
	[PostCommentIdTooShortWithMessageData]
	[PostCommentIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenCommentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var result = _requestValidator.TestValidate(request);

		// Assert
		result.ShouldHaveValidationErrorForCommentId(messageTransformer, request);
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
