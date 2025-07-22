using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetById;

public class GetPostByIdQueryRequestValidatorUnitTests : BasePostUnitTest
{
    private readonly GetPostByIdQueryRequest _request;
    private readonly GetPostByIdQueryRequestBuilder _requestBuilder;

    private readonly GetPostByIdQueryRequestValidator _requestValidator;

    public GetPostByIdQueryRequestValidatorUnitTests()
    {
        _requestBuilder = new();
        _request = _requestBuilder.Create();

        _requestValidator = new();
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

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
