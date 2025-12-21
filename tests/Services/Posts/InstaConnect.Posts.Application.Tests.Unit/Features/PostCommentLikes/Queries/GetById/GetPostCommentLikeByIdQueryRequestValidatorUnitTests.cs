namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Queries.GetById;

public class GetPostCommentLikeByIdQueryRequestValidatorUnitTests : BasePostCommentLikeApplicationQueryUnitTest
{
    private readonly GetPostCommentLikeByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostCommentLikeByIdQueryRequestBuilder _requestBuilder;
    private readonly GetPostCommentLikeByIdQueryRequest _request;

    private readonly GetPostCommentLikeByIdQueryRequestValidator _requestValidator;

    public GetPostCommentLikeByIdQueryRequestValidatorUnitTests()
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
    //[UserIdNullWithMessageData]
    //[UserIdEmptyWithMessageData]
    //[UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        var s = messageTransformer.Transform<GetPostCommentLikeByIdQueryRequest>(a => a.UserId, request.UserId);
        Console.WriteLine(s);

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
