﻿using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using Azure.Messaging;
using Bogus;
using FluentAssertions;
using InstaConnect.Messages.Web.FunctionalTests.Utilities;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Data;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Messages.Web.Models.Binding;
using InstaConnect.Messages.Web.Models.Responses;
using InstaConnect.Shared.Data.Models.Filters;
using MassTransit.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Tests.Commands;

public class UpdateMessageFunctionalTests : BaseMessageFunctionalTest
{
    public UpdateMessageFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel
        {
            Content = ValidUpdateContent
        };

        // Act
        var response = await HttpClient.PutAsJsonAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenIdIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{Faker.Random.AlphaNumeric(length)}",
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel()
        {
            Content = null!
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel()
        {
            Content = Faker.Random.AlphaNumeric(length)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel()
        {
            Content = ValidUpdateContent,
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel()
        {
            Content = ValidUpdateContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = Faker.Random.AlphaNumeric(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var request = new UpdateMessageBindingModel()
        {
            Content = ValidUpdateContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{MessageFunctionalTestConfigurations.NON_EXISTING_MESSAGE_ID}",
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnTheMessageIdInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingMessageSenderId = await CreateUserAsync(CancellationToken);
        var existingMessageReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingMessageSenderId, existingMessageReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel()
        {
            Content = ValidUpdateContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel()
        {
            Content = ValidUpdateContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel()
        {
            Content = ValidUpdateContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            request,
            CancellationToken);

        // Assert
        var messageViewResponse = await response
            .Content
            .ReadFromJsonAsync<MessageWriteViewResponse>();

        messageViewResponse
            .Should()
            .Match<MessageWriteViewResponse>(m => m.Id == existingMessageId);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateMessage_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel()
        {
            Content = ValidUpdateContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            request,
            CancellationToken);

        var message = await MessageWriteRepository.GetByIdAsync(existingMessageId, CancellationToken);

        message
            .Should()
            .Match<Message>(m => m.Id == existingMessageId &&
                                 m.SenderId == existingSenderId &&
                                 m.ReceiverId == existingReceiverId &&
                                 m.Content == ValidUpdateContent);
    }
}