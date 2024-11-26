using FluentValidation.TestHelper;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Application.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Queries.GetAllMessages;

public class GetAllMessagesQueryValidatorUnitTests : BaseMessageUnitTest
{
    private readonly GetAllMessagesQueryValidator _queryValidator;

    public GetAllMessagesQueryValidatorUnitTests()
    {
        _queryValidator = new(EntityPropertyValidator);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortOrder_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var query = new GetAllMessagesQuery(
            null!,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

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
        var query = new GetAllMessagesQuery(
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForReceiverId_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllMessagesQuery(
            MessageTestUtilities.ValidCurrentUserId,
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ReceiverId);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForReceiverName_WhenReceiverNameLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllMessagesQuery(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ReceiverName);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var query = new GetAllMessagesQuery(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            null!,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameDoesNotExist()
    {
        // Arrange
        var query = new GetAllMessagesQuery(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.InvalidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(SharedBusinessConfigurations.SORT_ORDER_MIN_LENGTH - 1)]
    [InlineData(SharedBusinessConfigurations.SORT_ORDER_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllMessagesQuery(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public void TestValidate_ShouldHaveAnErrorForOffset_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var query = new GetAllMessagesQuery(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            value,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Page);
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public void TestValidate_ShouldHaveAnErrorForLimit_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var query = new GetAllMessagesQuery(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            value);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PageSize);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var query = new GetAllMessagesQuery(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
