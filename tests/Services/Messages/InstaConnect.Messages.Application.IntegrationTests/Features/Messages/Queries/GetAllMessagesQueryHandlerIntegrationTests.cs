﻿using FluentAssertions;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Application.IntegrationTests.Features.Messages.Utilities;
using InstaConnect.Messages.Application.IntegrationTests.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Application.IntegrationTests.Features.Messages.Queries;

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
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            SharedTestUtilities.GetString(length),
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(MessageConfigurations.RECEIVER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageConfigurations.RECEIVER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(MessageConfigurations.RECEIVER_NAME_MIN_LENGTH - 1)]
    [InlineData(MessageConfigurations.RECEIVER_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenReceiverNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

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
            MessageTestUtilities.ValidSortOrderProperty,
            null!,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

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
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.InvalidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(SharedConfigurations.SortOrderMinLength - 1)]
    [InlineData(SharedConfigurations.SortOrderMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            value,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(SharedConfigurations.PageSizeMinValue - 1)]
    [InlineData(SharedConfigurations.PageSizeMaxValue + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingSenderId,
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
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
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

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
                                                           mc.Page == MessageTestUtilities.ValidPageValue &&
                                                           mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
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
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

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
                                                           mc.Page == MessageTestUtilities.ValidPageValue &&
                                                           mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
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
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

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
                                                           mc.Page == MessageTestUtilities.ValidPageValue &&
                                                           mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
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
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

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
                                                           mc.Page == MessageTestUtilities.ValidPageValue &&
                                                           mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
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
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

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
                                                           mc.Page == MessageTestUtilities.ValidPageValue &&
                                                           mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
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
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

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
                                                           mc.Page == MessageTestUtilities.ValidPageValue &&
                                                           mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
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
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

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
                                                           mc.Page == MessageTestUtilities.ValidPageValue &&
                                                           mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
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
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

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
                                                           mc.Page == MessageTestUtilities.ValidPageValue &&
                                                           mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
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
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

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
                                                           mc.Page == MessageTestUtilities.ValidPageValue &&
                                                           mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
