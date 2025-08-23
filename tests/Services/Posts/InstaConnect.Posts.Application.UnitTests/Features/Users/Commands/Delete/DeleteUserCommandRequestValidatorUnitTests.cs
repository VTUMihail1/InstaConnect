using System.Security.Cryptography.Xml;

using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Email;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.FirstName;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.LastName;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.ProfileImage;
using InstaConnect.Users.Application.Features.Users.Commands.Delete;
using InstaConnect.Users.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.DeleteApiRequest;

namespace InstaConnect.Users.Application.UnitTests.Features.Users.Commands.Delete;

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
