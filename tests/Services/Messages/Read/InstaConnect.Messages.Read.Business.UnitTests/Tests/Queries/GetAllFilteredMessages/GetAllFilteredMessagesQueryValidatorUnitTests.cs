using FluentValidation.TestHelper;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Read.Business.Utilities;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;

namespace InstaConnect.Messages.Write.Business.UnitTests.Tests.Commands.AddMessage;

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
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = null!,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Offset = ValidOffsetValue, 
            Limit = ValidLimitValue,
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
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForReceiverId_WhenReceiverIdIsNull()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = null!,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ReceiverId);
    }

    [Theory]
    [InlineData(default(int))]
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
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ReceiverId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForReceiverName_WhenReceiverNameIsNull()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = null!,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ReceiverName);
    }

    [Theory]
    [InlineData(default(int))]
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
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
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
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
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
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
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
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
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
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.LIMIT_MIN_VALUE - 1)]
    [InlineData(MessageBusinessConfigurations.LIMIT_MAX_VALUE + 1)]
    public void TestValidate_ShouldHaveAnErrorForOffset_WhenOffsetValueIsInvalid(int value)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Offset = value,
            Limit = ValidLimitValue,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Offset);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.LIMIT_MIN_VALUE - 1)]
    [InlineData(MessageBusinessConfigurations.LIMIT_MAX_VALUE + 1)]
    public void TestValidate_ShouldHaveAnErrorForLimit_WhenLimitValueIsInvalid(int value)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Offset = ValidOffsetValue,
            Limit = value,
        };

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Limit);
    }
}
