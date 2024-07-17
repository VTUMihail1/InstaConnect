using FluentAssertions;
using InstaConnect.Messages.Read.Business.Models;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Read.Business.Utilities;
using InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Messages.Write.Business.UnitTests.Tests.Commands.AddMessage;

public class GetAllFilteredMessagesQueryHandlerIntegrationTests : BaseMessageIntegrationTest
{
    public GetAllFilteredMessagesQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = null!,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = Faker.Random.AlphaNumeric(length),
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = Faker.Random.AlphaNumeric(length),
            ReceiverName = ValidReceiverName,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenReceiverNameLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = Faker.Random.AlphaNumeric(length),
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortOrderIsNull()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = null!,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.SORT_ORDER_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.SORT_ORDER_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortOrderLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = Faker.Random.AlphaNumeric(length),
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = null!,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.SORT_ORDER_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.SORT_ORDER_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = Faker.Random.AlphaNumeric(length),
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(MessageBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = value,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE - 1)]
    [InlineData(MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = ValidPageValue,
            PageSize = value,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenCurrentUserIdIsNotEmpty()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetAllFilteredMessagesQuery()
        {
            CurrentUserId = existingSenderId,
            ReceiverId = existingReceiverId,
            ReceiverName = MessageIntegrationTestConfigurations.EXISTING_SENDER_NAME,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = MessageBusinessConfigurations.PAGE_MIN_VALUE,
            PageSize = MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE,
        };

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationCollectionModel>(mc => mc.Items.Any(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.Content == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_CONTENT) &&
                                                           mc.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                           mc.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
                                                           mc.TotalCount == MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenReceiverIdIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetAllFilteredMessagesQuery()
        {
            CurrentUserId = existingSenderId,
            ReceiverId = null!,
            ReceiverName = MessageIntegrationTestConfigurations.EXISTING_SENDER_NAME,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = MessageBusinessConfigurations.PAGE_MIN_VALUE,
            PageSize = MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE,
        };

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationCollectionModel>(mc => mc.Items.Any(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.Content == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_CONTENT) &&
                                                           mc.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                           mc.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
                                                           mc.TotalCount == MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenReceiverIdIsEmpty()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetAllFilteredMessagesQuery()
        {
            CurrentUserId = existingSenderId,
            ReceiverId = string.Empty,
            ReceiverName = MessageIntegrationTestConfigurations.EXISTING_SENDER_NAME,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = MessageBusinessConfigurations.PAGE_MIN_VALUE,
            PageSize = MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE,
        };

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationCollectionModel>(mc => mc.Items.Any(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.Content == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_CONTENT) &&
                                                           mc.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                           mc.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
                                                           mc.TotalCount == MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenReceiverIdIsNotEmpty()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetAllFilteredMessagesQuery()
        {
            CurrentUserId = existingSenderId,
            ReceiverId = existingReceiverId,
            ReceiverName = MessageIntegrationTestConfigurations.EXISTING_SENDER_NAME,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = MessageBusinessConfigurations.PAGE_MIN_VALUE,
            PageSize = MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE,
        };

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationCollectionModel>(mc => mc.Items.Any(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.Content == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_CONTENT) &&
                                                           mc.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                           mc.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
                                                           mc.TotalCount == MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenReceiverNameIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetAllFilteredMessagesQuery()
        {
            CurrentUserId = existingSenderId,
            ReceiverId = existingReceiverId,
            ReceiverName = null!,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = MessageBusinessConfigurations.PAGE_MIN_VALUE,
            PageSize = MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE,
        };

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationCollectionModel>(mc => mc.Items.Any(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.Content == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_CONTENT) &&
                                                           mc.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                           mc.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
                                                           mc.TotalCount == MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenReceiverNameIsEmpty()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetAllFilteredMessagesQuery()
        {
            CurrentUserId = existingSenderId,
            ReceiverId = existingReceiverId,
            ReceiverName = string.Empty,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = MessageBusinessConfigurations.PAGE_MIN_VALUE,
            PageSize = MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE,
        };

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationCollectionModel>(mc => mc.Items.Any(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.Content == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_CONTENT) &&
                                                           mc.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                           mc.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
                                                           mc.TotalCount == MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenReceiverNameIsNotEmpty()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetAllFilteredMessagesQuery()
        {
            CurrentUserId = existingSenderId,
            ReceiverId = existingReceiverId,
            ReceiverName = MessageIntegrationTestConfigurations.EXISTING_SENDER_NAME,
            SortOrder = MessageIntegrationTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageIntegrationTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Page = MessageBusinessConfigurations.PAGE_MIN_VALUE,
            PageSize = MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE,
        };

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationCollectionModel>(mc => mc.Items.Any(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.Content == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_CONTENT) &&
                                                           mc.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                           mc.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
                                                           mc.TotalCount == MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
