using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Application.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetByIdQueryRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;

namespace InstaConnect.PostLikes.Application.UnitTests.Features.PostLikes.Queries.GetById;

public class GetPostLikeByIdQueryRequestValidatorUnitTests : BasePostLikeApplicationUnitTest
{
    private readonly GetPostLikeByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostLikeByIdQueryRequestBuilder _requestBuilder;
    private readonly GetPostLikeByIdQueryRequest _request;

    private readonly GetPostLikeByIdQueryRequestValidator _requestValidator;

    public GetPostLikeByIdQueryRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
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

    [Theory]
    [PostLikeIdNullWithMessageData]
    [PostLikeIdEmptyWithMessageData]
    [PostLikeIdTooShortWithMessageData]
    [PostLikeIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenLikeIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

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
