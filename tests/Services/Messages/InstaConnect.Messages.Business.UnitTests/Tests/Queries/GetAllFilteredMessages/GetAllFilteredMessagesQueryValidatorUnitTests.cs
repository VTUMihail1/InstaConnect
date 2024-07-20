using FluentValidation.TestHelper;
using InstaConnect.Messages.Business.UnitTests.Utilities;
using InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Utilities;

namespace InstaConnect.Messages.Business.UnitTests.Tests.Queries.GetAllFilteredMessages;

public class GetAllFilteredMessagesQueryValidatorUnitTests : BaseMessageUnitTest
{
    private readonly GetAllFilteredMessagesQueryValidator _validator;

    public GetAllFilteredMessagesQueryValidatorUnitTests()
    {
        _validator = new(
            EnumValidator,
            EntityPropertyValidator);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortOrder_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = null!,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

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
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = Faker.Random.AlphaNumeric(length),
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForReceiverId_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = Faker.Random.AlphaNumeric(length),
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ReceiverId);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForReceiverName_WhenReceiverNameLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = Faker.Random.AlphaNumeric(length),
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ReceiverName);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortOrder_WhenSortOrderIsNull()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = null!,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortOrder);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.SORT_ORDER_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.SORT_ORDER_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForSortOrder_WhenSortOrderLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = Faker.Random.AlphaNumeric(length),
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortOrder);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = null!,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.SORT_ORDER_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.SORT_ORDER_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = Faker.Random.AlphaNumeric(length),
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(MessageBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public void TestValidate_ShouldHaveAnErrorForOffset_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = value,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Page);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(MessageBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public void TestValidate_ShouldHaveAnErrorForLimit_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = value,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PageSize);
    }
}
