namespace InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Controllers.v1;

public class GetAllMessagesFunctionalTests : BaseMessageFunctionalTest
{
    public GetAllMessagesFunctionalTests(MessagesWebApplicationFactory messagesWebApplicationFactory) : base(messagesWebApplicationFactory)
    {

    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIsNull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            null,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            SharedTestUtilities.GetString(length),
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenReceiverNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenMessageDoesNotContainProperty()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.InvalidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.SortPropertyMinLength - 1)]
    [InlineData(SharedConfigurations.SortPropertyMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            value,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }



    [Theory]
    [InlineData(SharedConfigurations.PageSizeMinValue - 1)]
    [InlineData(SharedConfigurations.PageSizeMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            value
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessage.Id &&
                                                               m.Content == existingMessage.Content &&
                                                               m.SenderId == existingMessage.SenderId &&
                                                               m.SenderName == existingMessage.Sender.UserName &&
                                                               m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                                               m.ReceiverId == existingMessage.ReceiverId &&
                                                               m.ReceiverName == existingMessage.Receiver.UserName &&
                                                               m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage) &&
                                                               mc.Page == MessageTestUtilities.ValidPageValue &&
                                                               mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValidAndCurrentUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.SenderId),
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessage.Id &&
                                                               m.Content == existingMessage.Content &&
                                                               m.SenderId == existingMessage.SenderId &&
                                                               m.SenderName == existingMessage.Sender.UserName &&
                                                               m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                                               m.ReceiverId == existingMessage.ReceiverId &&
                                                               m.ReceiverName == existingMessage.Receiver.UserName &&
                                                               m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage) &&
                                                               mc.Page == MessageTestUtilities.ValidPageValue &&
                                                               mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValidAndReceiverIdCaseDoesNotMatch()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.ReceiverId),
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessage.Id &&
                                                               m.Content == existingMessage.Content &&
                                                               m.SenderId == existingMessage.SenderId &&
                                                               m.SenderName == existingMessage.Sender.UserName &&
                                                               m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                                               m.ReceiverId == existingMessage.ReceiverId &&
                                                               m.ReceiverName == existingMessage.Receiver.UserName &&
                                                               m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage) &&
                                                               mc.Page == MessageTestUtilities.ValidPageValue &&
                                                               mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValidAndReceiverNameCaseDoesNotMatch()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.Receiver.UserName),
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessage.Id &&
                                                               m.Content == existingMessage.Content &&
                                                               m.SenderId == existingMessage.SenderId &&
                                                               m.SenderName == existingMessage.Sender.UserName &&
                                                               m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                                               m.ReceiverId == existingMessage.ReceiverId &&
                                                               m.ReceiverName == existingMessage.Receiver.UserName &&
                                                               m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage) &&
                                                               mc.Page == MessageTestUtilities.ValidPageValue &&
                                                               mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValidAndReceiverNameIsNotFull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            SharedTestUtilities.GetHalfStartString(existingMessage.Receiver.UserName),
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessage.Id &&
                                                               m.Content == existingMessage.Content &&
                                                               m.SenderId == existingMessage.SenderId &&
                                                               m.SenderName == existingMessage.Sender.UserName &&
                                                               m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                                               m.ReceiverId == existingMessage.ReceiverId &&
                                                               m.ReceiverName == existingMessage.Receiver.UserName &&
                                                               m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage) &&
                                                               mc.Page == MessageTestUtilities.ValidPageValue &&
                                                               mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);

        // Act
        var response = await MessagesClient.GetAllAsync(existingMessage.SenderId, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessage.Id &&
                                                               m.Content == existingMessage.Content &&
                                                               m.SenderId == existingMessage.SenderId &&
                                                               m.SenderName == existingMessage.Sender.UserName &&
                                                               m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                                               m.ReceiverId == existingMessage.ReceiverId &&
                                                               m.ReceiverName == existingMessage.Receiver.UserName &&
                                                               m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage) &&
                                                               mc.Page == MessageTestUtilities.ValidPageValue &&
                                                               mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }
}
