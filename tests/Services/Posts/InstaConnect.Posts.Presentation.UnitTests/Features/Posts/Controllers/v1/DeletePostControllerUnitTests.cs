﻿using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Application.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Application.Features.Posts.Commands.DeletePost;
using InstaConnect.Posts.Application.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetPostById;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Controllers.v1;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Utilities;
using InstaConnect.Shared.Presentation.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;


public class DeletePostControllerUnitTests : BasePostUnitTest
{
    private readonly PostController _postController;

    public DeletePostControllerUnitTests()
    {
        _postController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new DeletePostRequest(existingPost.Id, existingPost.UserId);

        // Act
        var response = await _postController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new DeletePostRequest(existingPost.Id, existingPost.UserId);

        // Act
        await _postController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeletePostCommand>(m => m.Id == existingPost.Id &&
                                                    m.CurrentUserId == existingPost.UserId),
                                                    CancellationToken);
    }
}
