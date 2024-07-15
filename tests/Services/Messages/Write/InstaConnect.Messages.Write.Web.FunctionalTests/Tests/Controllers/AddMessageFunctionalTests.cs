using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using Bogus;
using FluentAssertions;
using InstaConnect.Messages.Write.Business.Utilities;
using InstaConnect.Messages.Write.Data.Abstractions;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Messages.Write.Web.FunctionalTests.Utilities;
using InstaConnect.Messages.Write.Web.Models.Binding;
using InstaConnect.Messages.Write.Web.Models.Responses;
using InstaConnect.Shared.Business.Contracts.Messages;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Tests.Commands;

public class AddMessageFunctionalTests : BaseMessageFunctionalTest
{
    public AddMessageFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var request = new AddMessageBindingModel
        {
            ReceiverId = MessageFunctionalTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidAddContent
        };

        // Act
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenReceiverIdIsNull()
    {
        // Arrange
        var request = new AddMessageBindingModel()
        {
            ReceiverId = null!,
            Content = ValidAddContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var request = new AddMessageBindingModel()
        {
            ReceiverId = Faker.Random.AlphaNumeric(length),
            Content = ValidAddContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var request = new AddMessageBindingModel()
        {
            ReceiverId = ValidReceiverId,
            Content = null!
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var request = new AddMessageBindingModel()
        {
            ReceiverId = ValidReceiverId,
            Content = Faker.Random.AlphaNumeric(length)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var request = new AddMessageBindingModel()
        {
            ReceiverId = ValidReceiverId,
            Content = ValidAddContent,
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var request = new AddMessageBindingModel()
        {
            ReceiverId = ValidReceiverId,
            Content = ValidAddContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = Faker.Random.AlphaNumeric(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIsInvalid()
    {
        // Arrange
        var request = new AddMessageBindingModel()
        {
            ReceiverId = MessageFunctionalTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidAddContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = MessageFunctionalTestConfigurations.NON_EXISTING_USER_ID;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenReceiverIsInvalid()
    {
        // Arrange
        var request = new AddMessageBindingModel()
        {
            ReceiverId = MessageFunctionalTestConfigurations.NON_EXISTING_USER_ID,
            Content = ValidAddContent
        };

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddMessageBindingModel
        {
            ReceiverId = MessageFunctionalTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidAddContent
        };

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddMessage_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddMessageBindingModel
        {
            ReceiverId = MessageFunctionalTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidAddContent
        };

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        var messageViewModel = await response
            .Content
            .ReadFromJsonAsync<MessageViewResponse>();

        var message = await MessageRepository.GetByIdAsync(messageViewModel!.Id, CancellationToken);

        // Assert
        message
            .Should()
            .Match<Message>(m => m.Id == messageViewModel.Id &&
                                 m.Content == ValidAddContent &&
                                 m.SenderId == MessageFunctionalTestConfigurations.EXISTING_SENDER_ID &&
                                 m.ReceiverId == MessageFunctionalTestConfigurations.EXISTING_RECEIVER_ID);
    }

    [Fact]
    public async Task AddAsync_ShouldPublishMessageCreatedEvent_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddMessageBindingModel
        {
            ReceiverId = MessageFunctionalTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidAddContent
        };

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        await TestHarness.Start();
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        var messageViewModel = await response
            .Content
            .ReadFromJsonAsync<MessageViewResponse>();

        await TestHarness.InactivityTask;

        var result = await TestHarness.Published.Any<MessageCreatedEvent>(m => m.Context.Message.Id == messageViewModel!.Id &&
                                                                               m.Context.Message.SenderId == MessageFunctionalTestConfigurations.EXISTING_SENDER_ID &&
                                                                               m.Context.Message.ReceiverId == MessageFunctionalTestConfigurations.EXISTING_RECEIVER_ID &&
                                                                               m.Context.Message.Content == ValidAddContent,
                                                                               CancellationToken);
        await TestHarness.Stop();

        // Assert
        result.Should().BeTrue();
    }
}
