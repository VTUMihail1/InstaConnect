namespace InstaConnect.Posts.Application.Tests.Unit.Features.Users.Commands.Delete;

public class DeleteUserCommandRequestValidatorUnitTests : BaseUserApplicationUnitTest
{
    private readonly DeleteUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteUserCommandRequestBuilder _requestBuilder;
    private readonly DeleteUserCommandRequest _request;

    private readonly DeleteUserCommandRequestValidator _requestValidator;

    public DeleteUserCommandRequestValidatorUnitTests()
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
    public void TestValidate_ShouldHaveAnError_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForId(errorMessage);
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
