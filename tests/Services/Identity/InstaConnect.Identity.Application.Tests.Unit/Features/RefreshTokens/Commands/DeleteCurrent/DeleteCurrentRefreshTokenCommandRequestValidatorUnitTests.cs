namespace InstaConnect.Identity.Application.Tests.Unit.Features.RefreshTokens.Commands.DeleteCurrent;

public class DeleteCurrentRefreshTokenCommandRequestValidatorUnitTests : BaseRefreshTokenApplicationCommandUnitTest
{
    private readonly DeleteCurrentRefreshTokenCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteCurrentRefreshTokenCommandRequestBuilder _requestBuilder;
    private readonly DeleteCurrentRefreshTokenCommandRequest _request;

    private readonly DeleteCurrentRefreshTokenCommandRequestValidator _requestValidator;

    public DeleteCurrentRefreshTokenCommandRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(RefreshToken);
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
    [RefreshTokenValueNullWithMessageData]
    [RefreshTokenValueEmptyWithMessageData]
    [RefreshTokenValueTooShortWithMessageData]
    [RefreshTokenValueTooLongWithMessageData]
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

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestIsValid()
    {
        // Act
        var result = _requestValidator.TestValidate(_request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }
}
