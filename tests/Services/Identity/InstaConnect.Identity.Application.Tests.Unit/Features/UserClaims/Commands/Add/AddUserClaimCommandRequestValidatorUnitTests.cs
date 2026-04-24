using InstaConnect.Common.Events.Features.Tokens.Models;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.UserClaims.Commands.Add;

public class AddUserClaimCommandRequestValidatorUnitTests : BaseUserClaimApplicationCommandUnitTest
{
    private readonly AddUserClaimCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddUserClaimCommandRequestBuilder _requestBuilder;
    private readonly AddUserClaimCommandRequest _request;

    private readonly AddUserClaimCommandRequestValidator _requestValidator;

    public AddUserClaimCommandRequestValidatorUnitTests()
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
    [UserClaimClaimEmptyWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenClaimIsInvalid(
        IEnumTransformer<ApplicationClaims> transformer, IEnumMessageTransformer<ApplicationClaims> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithClaim(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForClaim(messageTransformer, request);
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
