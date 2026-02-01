namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Commands.Update;

public class UpdatePostCommandRequestValidatorUnitTests : BasePostApplicationCommandUnitTest
{
    private readonly UpdatePostCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdatePostCommandRequestBuilder _requestBuilder;
    private readonly UpdatePostCommandRequest _request;

    private readonly UpdatePostCommandRequestValidator _requestValidator;

    public UpdatePostCommandRequestValidatorUnitTests()
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

    [Theory]
    [PostTitleNullWithMessageData]
    [PostTitleEmptyWithMessageData]
    [PostTitleTooShortWithMessageData]
    [PostTitleTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenTitleIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForTitle(messageTransformer, request);
    }

    [Theory]
    [PostContentNullWithMessageData]
    [PostContentEmptyWithMessageData]
    [PostContentTooShortWithMessageData]
    [PostContentTooLongWithMessageData]
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
