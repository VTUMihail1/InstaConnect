using FluentValidation.TestHelper;
using InstaConnect.Follows.Business.Features.Follows.Utilities;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetPostLikeById;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Queries.GetFollowById;

public class GetPostLikeByIdQueryValidatorUnitTests : BasePostLikeUnitTest
{
    private readonly GetPostLikeByIdQueryValidator _validator;

    public GetPostLikeByIdQueryValidatorUnitTests()
    {
        _validator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(null!);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(Faker.Random.AlphaNumeric(length));

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }
}
