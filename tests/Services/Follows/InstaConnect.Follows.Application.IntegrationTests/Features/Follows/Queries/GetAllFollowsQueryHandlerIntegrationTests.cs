using FluentAssertions;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Application.IntegrationTests.Features.Follows.Utilities;
using InstaConnect.Follows.Application.IntegrationTests.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Application.IntegrationTests.Features.Follows.Queries;

public class GetAllFollowsQueryHandlerIntegrationTests : BaseFollowIntegrationTest
{
    public GetAllFollowsQueryHandlerIntegrationTests(FollowsWebApplicationFactory followsWebApplicationFactory) : base(followsWebApplicationFactory)
    {
    }

    [Theory]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            SharedTestUtilities.GetString(length),
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            SharedTestUtilities.GetString(length),
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            SharedTestUtilities.GetString(length),
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFollowingNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            SharedTestUtilities.GetString(length),
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }


    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            null,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenMessageDoesNotContaintSortPropertyName()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.InvalidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            value,
            FollowTestUtilities.ValidPageSizeValue);

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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            value);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            null,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenCurrentUserIdIsEmpty()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            string.Empty,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenCurrentUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            SharedTestUtilities.GetNonCaseMatchingString(existingFollow.FollowerId),
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenCurrentUserNameIsNull()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            null,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenCurrentUserNameIsEmpty()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            string.Empty,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenCurrentUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            SharedTestUtilities.GetNonCaseMatchingString(existingFollow.Follower.UserName),
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenCurrentUserIsNotFull()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            SharedTestUtilities.GetHalfStartString(existingFollow.Follower.UserName),
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenFollowingIdIsNull()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            null,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenFollowingIdIsEmpty()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            string.Empty,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenFollowingIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingFollow.FollowingId),
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenFollowingNameIsNull()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            null,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenFollowingNameIsEmpty()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            string.Empty,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenFollowingNameCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            SharedTestUtilities.GetNonCaseMatchingString(existingFollow.Following.UserName),
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenFollowingNameIsNotFull()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            SharedTestUtilities.GetHalfStartString(existingFollow.Following.UserName),
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                                    m.FollowerId == existingFollow.FollowerId &&
                                                                    m.FollowerName == existingFollow.Follower.UserName &&
                                                                    m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                    m.FollowingId == existingFollow.FollowingId &&
                                                                    m.FollowingName == existingFollow.Following.UserName &&
                                                                    m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
