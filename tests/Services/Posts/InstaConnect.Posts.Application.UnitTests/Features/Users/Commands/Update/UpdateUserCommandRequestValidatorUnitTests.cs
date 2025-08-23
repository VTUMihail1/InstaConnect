using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Email;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.FirstName;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.LastName;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.ProfileImage;
using InstaConnect.Users.Application.Features.Users.Commands.Add;
using InstaConnect.Users.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.UpdateApiRequest;

namespace InstaConnect.Users.Application.UnitTests.Features.Users.Commands.Update;

public class UpdateUserCommandRequestValidatorUnitTests : BaseUserApplicationUnitTest
{
    private readonly UpdateUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdateUserCommandRequestBuilder _requestBuilder;
    private readonly UpdateUserCommandRequest _request;

    private readonly UpdateUserCommandRequestValidator _requestValidator;

    public UpdateUserCommandRequestValidatorUnitTests()
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

    [Theory]
    [UserNameNullWithMessageData]
    [UserNameEmptyWithMessageData]
    [UserNameTooShortWithMessageData]
    [UserNameTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithName(_request.Name, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForName(errorMessage);
    }

    [Theory]
    [UserFirstNameNullWithMessageData]
    [UserFirstNameEmptyWithMessageData]
    [UserFirstNameTooShortWithMessageData]
    [UserFirstNameTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenFirstNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithFirstName(_request.FirstName, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForFirstName(errorMessage);
    }

    [Theory]
    [UserLastNameNullWithMessageData]
    [UserLastNameEmptyWithMessageData]
    [UserLastNameTooShortWithMessageData]
    [UserLastNameTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenLastNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithLastName(_request.LastName, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForLastName(errorMessage);
    }

    [Theory]
    [UserEmailNullWithMessageData]
    [UserEmailEmptyWithMessageData]
    [UserEmailTooShortWithMessageData]
    [UserEmailTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenEmailIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(_request.Email, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForEmail(errorMessage);
    }

    [Theory]
    [UserProfileImageTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenProfileImageIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(_request.ProfileImage, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForProfileImage(errorMessage);
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
    [UserProfileImageEmptyData]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestAndProfileImageAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(_request.ProfileImage, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }
}
