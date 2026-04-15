namespace InstaConnect.Identity.Application.Tests.Unit.Features.EmailConfirmationTokens.Commands.Verify;

public class VerifyEmailConfirmationTokenCommandRequestValidatorUnitTests : BaseEmailConfirmationTokenApplicationCommandUnitTest
{
    private readonly VerifyEmailConfirmationTokenCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly VerifyEmailConfirmationTokenCommandRequestBuilder _requestBuilder;
    private readonly VerifyEmailConfirmationTokenCommandRequest _request;

    private readonly VerifyEmailConfirmationTokenCommandRequestValidator _requestValidator;

    public VerifyEmailConfirmationTokenCommandRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(EmailConfirmationToken);
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
    [EmailConfirmationTokenValueNullWithMessageData]
    [EmailConfirmationTokenValueEmptyWithMessageData]
    [EmailConfirmationTokenValueTooShortWithMessageData]
    [EmailConfirmationTokenValueTooLongWithMessageData]
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
