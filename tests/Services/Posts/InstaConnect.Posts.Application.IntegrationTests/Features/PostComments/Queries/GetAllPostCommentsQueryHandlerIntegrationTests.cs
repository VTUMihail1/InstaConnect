﻿using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Application.IntegrationTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostComments.Queries;

public class GetAllPostCommentsQueryHandlerIntegrationTests : BasePostCommentIntegrationTest
{
    public GetAllPostCommentsQueryHandlerIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            SharedTestUtilities.GetString(length),
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetString(length),
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            UserTestUtilities.ValidName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            null,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenMessageDoesNotContaintSortPropertyName()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            UserTestUtilities.ValidName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.InvalidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

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
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            UserTestUtilities.ValidName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

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
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            UserTestUtilities.ValidName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            value,
            PostCommentTestUtilities.ValidPageSizeValue);

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
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            UserTestUtilities.ValidName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            value);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenUserIdIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            null,
            UserTestUtilities.ValidName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostComment.Id &&
                                                                    m.UserId == existingPostComment.UserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.PostId == existingPostComment.PostId &&
                                                                    m.Content == existingPostComment.Content) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenUserIdIsEmpty()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            string.Empty,
            UserTestUtilities.ValidName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostComment.Id &&
                                                                    m.UserId == existingPostComment.UserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.PostId == existingPostComment.PostId &&
                                                                    m.Content == existingPostComment.Content) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostComment.UserId),
            UserTestUtilities.ValidName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostComment.Id &&
                                                                    m.UserId == existingPostComment.UserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.PostId == existingPostComment.PostId &&
                                                                    m.Content == existingPostComment.Content) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenUserNameIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            null,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostComment.Id &&
                                                                    m.UserId == existingPostComment.UserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.PostId == existingPostComment.PostId &&
                                                                    m.Content == existingPostComment.Content) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenUserNameIsEmpty()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            string.Empty,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostComment.Id &&
                                                                    m.UserId == existingPostComment.UserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.PostId == existingPostComment.PostId &&
                                                                    m.Content == existingPostComment.Content) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostComment.Id &&
                                                                    m.UserId == existingPostComment.UserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.PostId == existingPostComment.PostId &&
                                                                    m.Content == existingPostComment.Content) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenPostIdIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            UserTestUtilities.ValidName,
            null,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostComment.Id &&
                                                                    m.UserId == existingPostComment.UserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.PostId == existingPostComment.PostId &&
                                                                    m.Content == existingPostComment.Content) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenPostIdIsEmpty()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            UserTestUtilities.ValidName,
            string.Empty,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostComment.Id &&
                                                                    m.UserId == existingPostComment.UserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.PostId == existingPostComment.PostId &&
                                                                    m.Content == existingPostComment.Content) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenPostIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostComment.PostId),
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostComment.Id &&
                                                                    m.UserId == existingPostComment.UserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.PostId == existingPostComment.PostId &&
                                                                    m.Content == existingPostComment.Content) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            UserTestUtilities.ValidName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostComment.Id &&
                                                                    m.UserId == existingPostComment.UserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.PostId == existingPostComment.PostId &&
                                                                    m.Content == existingPostComment.Content) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
