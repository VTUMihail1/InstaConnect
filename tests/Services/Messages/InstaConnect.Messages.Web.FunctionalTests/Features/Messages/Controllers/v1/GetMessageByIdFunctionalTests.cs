﻿using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Web.Features.Messages.Models.Responses;
using InstaConnect.Messages.Web.FunctionalTests.Features.Messages.Utilities;
using InstaConnect.Messages.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Web.FunctionalTests.Features.Messages.Controllers.v1;

public class GetMessageByIdFunctionalTests : BaseMessageFunctionalTest
{
    public GetMessageByIdFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingMessageId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetIdRoute(SharedTestUtilities.GetString(length)), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetIdRoute(existingMessageId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetString(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetIdRoute(existingMessageId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetIdRoute(MessageTestUtilities.InvalidId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdCurrentUserIdDoesNotOwnMessage()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingMessageSenderId = await CreateUserAsync(CancellationToken);
        var existingMessageReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingMessageSenderId, existingMessageReceiverId, CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetIdRoute(existingMessageId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetIdRoute(existingMessageId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMessageViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetIdRoute(existingMessageId), CancellationToken);

        var messageViewResponse = await response
            .Content
            .ReadFromJsonAsync<MessageQueryViewResponse>();

        // Assert
        messageViewResponse
            .Should()
            .Match<MessageQueryViewResponse>(m => m.Id == existingMessageId &&
                                 m.Content == MessageTestUtilities.ValidContent &&
                                 m.SenderId == existingSenderId &&
                                 m.SenderName == MessageTestUtilities.ValidUserName &&
                                 m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                 m.ReceiverId == existingReceiverId &&
                                 m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                 m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMessageViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetIdRoute(SharedTestUtilities.GetNonCaseMatchingString(existingMessageId)), CancellationToken);

        var messageViewResponse = await response
            .Content
            .ReadFromJsonAsync<MessageQueryViewResponse>();

        // Assert
        messageViewResponse
            .Should()
            .Match<MessageQueryViewResponse>(m => m.Id == existingMessageId &&
                                 m.Content == MessageTestUtilities.ValidContent &&
                                 m.SenderId == existingSenderId &&
                                 m.SenderName == MessageTestUtilities.ValidUserName &&
                                 m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                 m.ReceiverId == existingReceiverId &&
                                 m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                 m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage);
    }
}
