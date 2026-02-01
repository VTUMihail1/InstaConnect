namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Commands.Add;

public class AddPostCommentCommandRequestValidatorUnitTests : BasePostCommentApplicationCommandUnitTest
{
    private readonly AddPostCommentCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostCommentCommandRequestBuilder _requestBuilder;
    private readonly AddPostCommentCommandRequest _request;

    private readonly AddPostCommentCommandRequestValidator _requestValidator;

    public AddPostCommentCommandRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, User);
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

        var message = messageTransformer.Transform<AddPostCommentCommandRequest>(r => r.Content, request.Content);

        Console.WriteLine(message);

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
