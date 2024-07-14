using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using Bogus;
using FluentAssertions;
using InstaConnect.Messages.Write.Business.Utilities;
using InstaConnect.Messages.Write.Data.Abstractions;
using InstaConnect.Messages.Write.Web.FunctionalTests.Utilities;
using InstaConnect.Messages.Write.Web.Models.Responses;
using InstaConnect.Shared.Business.Contracts.Messages;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Tests.Commands;

public class DeleteMessageFunctionalTests : BaseMessageFunctionalTest
{
    public DeleteMessageFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);

        // Act
        var response = await HttpClient.DeleteAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenIdIsInvalid(int length)
    {
        // Arrange
        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{Faker.Random.AlphaNumeric(length)}",
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = Faker.Random.AlphaNumeric(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        ValidJwtConfig[ClaimTypes.NameIdentifier] = MessageFunctionalTestConfigurations.EXISTING_MESSAGE_SENDER_ID;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{MessageFunctionalTestConfigurations.NON_EXISTING_MESSAGE_ID}",
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnTheMessageIdInvalid()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = MessageFunctionalTestConfigurations.EXISTING_MESSAGE_SENDER_ID;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteMessage_WhenRequestIsValid()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = MessageFunctionalTestConfigurations.EXISTING_MESSAGE_SENDER_ID;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
         await HttpClient.DeleteAsync(
            $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
            CancellationToken);

        var message = await MessageRepository.GetByIdAsync(existingMessageId, CancellationToken);

        // Assert
        message
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldPublishMessage_WhenRequestIsValid()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = MessageFunctionalTestConfigurations.EXISTING_MESSAGE_SENDER_ID;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        await TestHarness.Start();
        await HttpClient.DeleteAsync(
           $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/{existingMessageId}",
           CancellationToken);

        await TestHarness.InactivityTask;

        var result = await TestHarness.Published.Any<MessageDeletedEvent>(m => m.Context.Message.Id == existingMessageId, CancellationToken);
        await TestHarness.Stop();

        // Assert
        result.Should().BeTrue();
    }
}
