namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Commands.Add;

public class AddUserCommandRequestValidatorUnitTests : BaseUserApplicationCommandUnitTest
{
    private const string PasswordPropertyName = nameof(AddUserCommandRequest.Password);

    private readonly AddUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddUserCommandRequestBuilder _requestBuilder;
    private readonly AddUserCommandRequest _request;

    private readonly AddUserCommandRequestValidator _requestValidator;

    public AddUserCommandRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create();
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
    [UserFirstNameNullWithMessageData]
    [UserFirstNameEmptyWithMessageData]
    [UserFirstNameTooShortWithMessageData]
    [UserFirstNameTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenFirstNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithFirstName(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForFirstName(messageTransformer, request);
    }

    [Theory]
    [UserLastNameNullWithMessageData]
    [UserLastNameEmptyWithMessageData]
    [UserLastNameTooShortWithMessageData]
    [UserLastNameTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenLastNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithLastName(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForLastName(messageTransformer, request);
    }

    [Theory]
    [UserEmailNullWithMessageData]
    [UserEmailEmptyWithMessageData]
    [UserEmailTooShortWithMessageData]
    [UserEmailTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenEmailIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForEmail(messageTransformer, request);
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

    [Theory]
    [UserConfirmPasswordNotEqualWithMessageData(PasswordPropertyName)]
    public void TestValidate_ShouldHaveAnError_WhenConfirmPasswordIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithConfirmPassword(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForConfirmPassword(messageTransformer, request);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestIsValid()
    {
        // Act
        var result = _requestValidator.TestValidate(_request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }

    [Theory]
    [UserProfileImageNullData]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestAndProfileImageAreValid(
        IFormFileTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }
}
