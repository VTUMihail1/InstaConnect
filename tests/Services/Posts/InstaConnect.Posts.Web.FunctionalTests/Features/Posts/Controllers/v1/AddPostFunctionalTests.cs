﻿using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Web.Features.Posts.Models.Binding;
using InstaConnect.Posts.Web.Features.Posts.Models.Responses;
using InstaConnect.Posts.Web.FunctionalTests.Features.Posts.Utilities;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Web.FunctionalTests.Features.Posts.Controllers.v1;

public class AddPostFunctionalTests : BasePostFunctionalTest
{
    public AddPostFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new AddPostBindingModel(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent);

        // Act
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenTitleIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new AddPostBindingModel(null!, PostTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.TITLE_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.TITLE_MAX_LENGTH + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new AddPostBindingModel(SharedTestUtilities.GetString(length), PostTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new AddPostBindingModel(PostTestUtilities.ValidAddTitle, null!);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new AddPostBindingModel(PostTestUtilities.ValidAddTitle, SharedTestUtilities.GetString(length));

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new AddPostBindingModel(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new AddPostBindingModel(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetString(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new AddPostBindingModel(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = PostTestUtilities.InvalidUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new AddPostBindingModel(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent);


        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPost_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new AddPostBindingModel(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        var postViewResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommandResponse>();

        var post = await PostWriteRepository.GetByIdAsync(postViewResponse!.Id, CancellationToken);

        // Assert
        post
            .Should()
            .Match<Post>(m => m.Id == postViewResponse.Id &&
                                 m.UserId == existingUserId &&
                                 m.Content == PostTestUtilities.ValidAddContent &&
                                 m.Title == PostTestUtilities.ValidAddTitle);
    }
}
