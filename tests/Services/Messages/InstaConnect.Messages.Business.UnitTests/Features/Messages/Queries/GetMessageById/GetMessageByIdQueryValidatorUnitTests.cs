using FluentValidation.TestHelper;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Business.Features.Messages.Utilities;
using InstaConnect.Messages.Business.UnitTests.Features.Messages.Utilities;

namespace InstaConnect.Messages.Business.UnitTests.Features.Messages.Queries.GetMessageById;

public class GetMessageByIdQueryValidatorUnitTests : BaseMessageUnitTest
{
    private readonly GetMessageByIdQueryValidator _validator;

    public GetMessageByIdQueryValidatorUnitTests()
    {
        _validator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var query = new GetMessageByIdQuery(
            null!,
            ValidCurrentUserId
        );

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetMessageByIdQuery(
            Faker.Random.AlphaNumeric(length),
            ValidCurrentUserId
        );

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var query = new GetMessageByIdQuery(
            ValidId,
            null!
        );

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetMessageByIdQuery(
            ValidId,
            Faker.Random.AlphaNumeric(length)
        );

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }
}
