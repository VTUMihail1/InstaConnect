namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Queries.GetCurrentDetailsById;

public class GetCurrentUserDetailsByIdQueryRequestValidatorUnitTests : BaseUserApplicationQueryUnitTest
{
    private readonly GetCurrentUserDetailsByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetCurrentUserDetailsByIdQueryRequestBuilder _requestBuilder;
    private readonly GetCurrentUserDetailsByIdQueryRequest _request;

    private readonly GetCurrentUserDetailsByIdQueryRequestValidator _requestValidator;

    public GetCurrentUserDetailsByIdQueryRequestValidatorUnitTests()
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
