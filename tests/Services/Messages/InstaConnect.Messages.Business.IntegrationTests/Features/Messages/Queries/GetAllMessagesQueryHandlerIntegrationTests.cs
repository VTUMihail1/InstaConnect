using FluentAssertions;
using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Business.IntegrationTests.Features.Messages.Utilities;
using InstaConnect.Messages.Business.IntegrationTests.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Business.IntegrationTests.Features.Messages.Queries;

public class GetAllMessagesQueryHandlerIntegrationTests : BaseMessageIntegrationTest
{
    public GetAllMessagesQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            null!,
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            SharedTestUtilities.GetString(length),
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            SharedTestUtilities.GetString(length),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            null!,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenMessageDoesNotContaintSortPropertyName()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            InvalidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(SharedBusinessConfigurations.SORT_ORDER_MIN_LENGTH - 1)]
    [InlineData(SharedBusinessConfigurations.SORT_ORDER_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            value,
            ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MAX_VALUE + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            value);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenCurrentUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetAllMessagesQuery(
            SharedTestUtilities.GetNonCaseMatchingString(existingSenderId),
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.SenderName == MessageTestUtilities.ValidUserName &&
                                                                    m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                                    m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.Content == MessageTestUtilities.ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
        var query = new GetAllMessagesQuery(
            existingSenderId,
            null!,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.SenderName == MessageTestUtilities.ValidUserName &&
                                                                    m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                                    m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.Content == MessageTestUtilities.ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
        var query = new GetAllMessagesQuery(
            existingSenderId,
            string.Empty,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.SenderName == MessageTestUtilities.ValidUserName &&
                                                                    m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                                    m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.Content == MessageTestUtilities.ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenReceiverIdCaseDoesNotMatch()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            SharedTestUtilities.GetNonCaseMatchingString(existingReceiverId),
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.SenderName == MessageTestUtilities.ValidUserName &&
                                                                    m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                                    m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.Content == MessageTestUtilities.ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            null!,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.SenderName == MessageTestUtilities.ValidUserName &&
                                                                    m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                                    m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.Content == MessageTestUtilities.ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            string.Empty,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.SenderName == MessageTestUtilities.ValidUserName &&
                                                                    m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                                    m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.Content == MessageTestUtilities.ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenReceiverNameCaseDoesNotMatch()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            SharedTestUtilities.GetNonCaseMatchingString(MessageTestUtilities.ValidUserName),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.SenderName == MessageTestUtilities.ValidUserName &&
                                                                    m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                                    m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.Content == MessageTestUtilities.ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenReceiverNameIsNotFull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            SharedTestUtilities.GetHalfStartString(MessageTestUtilities.ValidUserName),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.SenderName == MessageTestUtilities.ValidUserName &&
                                                                    m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                                    m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.Content == MessageTestUtilities.ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessageId &&
                                                                    m.SenderId == existingSenderId &&
                                                                    m.SenderName == MessageTestUtilities.ValidUserName &&
                                                                    m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.ReceiverId == existingReceiverId &&
                                                                    m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                                    m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                    m.Content == MessageTestUtilities.ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
