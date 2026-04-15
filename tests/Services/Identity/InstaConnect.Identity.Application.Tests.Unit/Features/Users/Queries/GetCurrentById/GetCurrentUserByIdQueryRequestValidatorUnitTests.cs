namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Queries.GetCurrentById;

public class GetCurrentUserByIdQueryRequestValidatorUnitTests : BaseUserApplicationQueryUnitTest
{
    private readonly GetCurrentUserByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetCurrentUserByIdQueryRequestBuilder _requestBuilder;
    private readonly GetCurrentUserByIdQueryRequest _request;

    private readonly GetCurrentUserByIdQueryRequestValidator _requestValidator;

    public GetCurrentUserByIdQueryRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _requestValidator = new();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenCurrentIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentId(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForCurrentId(messageTransformer, request);
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
