namespace InstaConnect.Identity.Application.Tests.Unit.Features.RefreshTokens.Commands.Rotate;

public class RotateRefreshTokenCommandRequestValidatorUnitTests : BaseRefreshTokenApplicationCommandUnitTest
{
    private readonly RotateRefreshTokenCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly RotateRefreshTokenCommandRequestBuilder _requestBuilder;
    private readonly RotateRefreshTokenCommandRequest _request;

    private readonly RotateRefreshTokenCommandRequestValidator _requestValidator;

    public RotateRefreshTokenCommandRequestValidatorUnitTests()
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
