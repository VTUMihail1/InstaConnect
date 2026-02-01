namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Commands.Update;

public class UpdatePostCommentCommandRequestValidatorUnitTests : BasePostCommentApplicationCommandUnitTest
{
    private readonly UpdatePostCommentCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdatePostCommentCommandRequestBuilder _requestBuilder;
    private readonly UpdatePostCommentCommandRequest _request;

    private readonly UpdatePostCommentCommandRequestValidator _requestValidator;

    public UpdatePostCommentCommandRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
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

    [Theory]
    [PostCommentContentNullWithMessageData]
    [PostCommentContentEmptyWithMessageData]
    [PostCommentContentTooShortWithMessageData]
    [PostCommentContentTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenContentIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithContent(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForContent(messageTransformer, request);
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
