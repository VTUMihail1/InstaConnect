﻿using FluentAssertions;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Application.IntegrationTests.Features.Messages.Utilities;
using InstaConnect.Messages.Application.IntegrationTests.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            null!,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
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
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            SharedTestUtilities.GetString(length),
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
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
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidName,
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
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenReceiverNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            existingMessage.ReceiverId,
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.Id),
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessage.Id &&
                                                                    m.SenderId == existingMessage.Id &&
                                                                    m.SenderName == UserTestUtilities.ValidName &&
                                                                    m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.ReceiverId == existingMessage.ReceiverId &&
                                                                    m.ReceiverName == UserTestUtilities.ValidName &&
                                                                    m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            null!,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessage.Id &&
                                                                    m.SenderId == existingMessage.Id &&
                                                                    m.SenderName == UserTestUtilities.ValidName &&
                                                                    m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.ReceiverId == existingMessage.ReceiverId &&
                                                                    m.ReceiverName == UserTestUtilities.ValidName &&
                                                                    m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            string.Empty,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessage.Id &&
                                                                    m.SenderId == existingMessage.Id &&
                                                                    m.SenderName == UserTestUtilities.ValidName &&
                                                                    m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.ReceiverId == existingMessage.ReceiverId &&
                                                                    m.ReceiverName == UserTestUtilities.ValidName &&
                                                                    m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.ReceiverId),
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessage.Id &&
                                                                    m.SenderId == existingMessage.Id &&
                                                                    m.SenderName == UserTestUtilities.ValidName &&
                                                                    m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.ReceiverId == existingMessage.ReceiverId &&
                                                                    m.ReceiverName == UserTestUtilities.ValidName &&
                                                                    m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            existingMessage.ReceiverId,
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
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessage.Id &&
                                                                    m.SenderId == existingMessage.Id &&
                                                                    m.SenderName == UserTestUtilities.ValidName &&
                                                                    m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.ReceiverId == existingMessage.ReceiverId &&
                                                                    m.ReceiverName == UserTestUtilities.ValidName &&
                                                                    m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            existingMessage.ReceiverId,
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
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessage.Id &&
                                                                    m.SenderId == existingMessage.Id &&
                                                                    m.SenderName == UserTestUtilities.ValidName &&
                                                                    m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.ReceiverId == existingMessage.ReceiverId &&
                                                                    m.ReceiverName == UserTestUtilities.ValidName &&
                                                                    m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            existingMessage.ReceiverId,
            SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessage.Id &&
                                                                    m.SenderId == existingMessage.Id &&
                                                                    m.SenderName == UserTestUtilities.ValidName &&
                                                                    m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.ReceiverId == existingMessage.ReceiverId &&
                                                                    m.ReceiverName == UserTestUtilities.ValidName &&
                                                                    m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            existingMessage.ReceiverId,
            SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidName),
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessage.Id &&
                                                                    m.SenderId == existingMessage.Id &&
                                                                    m.SenderName == UserTestUtilities.ValidName &&
                                                                    m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.ReceiverId == existingMessage.ReceiverId &&
                                                                    m.ReceiverName == UserTestUtilities.ValidName &&
                                                                    m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetAllMessagesQuery(
            existingMessage.Id,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessage.Id &&
                                                                    m.SenderId == existingMessage.Id &&
                                                                    m.SenderName == UserTestUtilities.ValidName &&
                                                                    m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.ReceiverId == existingMessage.ReceiverId &&
                                                                    m.ReceiverName == UserTestUtilities.ValidName &&
                                                                    m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.Content == MessageTestUtilities.ValidContent) &&
                                                           mc.Page == MessageTestUtilities.ValidPageValue &&
                                                           mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
