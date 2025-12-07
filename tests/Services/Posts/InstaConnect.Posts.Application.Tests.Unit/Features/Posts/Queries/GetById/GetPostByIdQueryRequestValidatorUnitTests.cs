namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Queries.GetById;

public class GetPostByIdQueryRequestValidatorUnitTests : BasePostApplicationUnitTest
{
    private readonly GetPostByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostByIdQueryRequestBuilder _requestBuilder;
    private readonly GetPostByIdQueryRequest _request;

    private readonly GetPostByIdQueryRequestValidator _requestValidator;

    public GetPostByIdQueryRequestValidatorUnitTests()
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

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestIsValid()
    {
        // Act
        var result = _requestValidator.TestValidate(_request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }
}
