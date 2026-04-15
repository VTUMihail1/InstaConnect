namespace InstaConnect.Identity.Application.Tests.Unit.Features.RefreshTokens.Commands.Issue;

public class IssueRefreshTokenCommandRequestValidatorUnitTests : BaseRefreshTokenApplicationCommandUnitTest
{
    private readonly IssueRefreshTokenCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly IssueRefreshTokenCommandRequestBuilder _requestBuilder;
    private readonly IssueRefreshTokenCommandRequest _request;

    private readonly IssueRefreshTokenCommandRequestValidator _requestValidator;

    public IssueRefreshTokenCommandRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User, Password);
        _request = _requestBuilder.Build();

        _requestValidator = new();
    }

    [Theory]
    [UserNameNullWithMessageData]
    [UserNameEmptyWithMessageData]
    [UserNameTooShortWithMessageData]
    [UserNameTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForName(messageTransformer, request);
    }

    [Theory]
    [UserPasswordNullWithMessageData]
    [UserPasswordEmptyWithMessageData]
    [UserPasswordTooShortWithMessageData]
    [UserPasswordTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenPasswordIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPassword(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPassword(messageTransformer, request);
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
