using FluentAssertions;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Application.IntegrationTests.Features.Follows.Utilities;
using InstaConnect.Follows.Application.IntegrationTests.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Application.IntegrationTests.Features.Follows.Queries;

public class GetAllFollowsQueryHandlerIntegrationTests : BaseFollowIntegrationTest
{
    public GetAllFollowsQueryHandlerIntegrationTests(FollowsIntegrationTestWebAppFactory followIntegrationTestWebAppFactory) : base(followIntegrationTestWebAppFactory)
    {
    }

    [Theory]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidName,
            existingFollowingId,
            UserTestUtilities.ValidName,
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            SharedTestUtilities.GetString(length),
            existingFollowingId,
            UserTestUtilities.ValidName,
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidName,
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            existingFollowingId,
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            existingFollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            null!,
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            existingFollowingId,
            UserTestUtilities.ValidName,
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
    [InlineData(SharedBusinessConfigurations.SORT_ORDER_MIN_LENGTH - 1)]
    [InlineData(SharedBusinessConfigurations.SORT_ORDER_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            existingFollowingId,
            UserTestUtilities.ValidName,
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
    [InlineData(SharedBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            existingFollowingId,
            UserTestUtilities.ValidName,
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
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MAX_VALUE + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            existingFollowingId,
            UserTestUtilities.ValidName,
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            null!,
            UserTestUtilities.ValidName,
            existingFollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            string.Empty,
            UserTestUtilities.ValidName,
            existingFollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            SharedTestUtilities.GetNonCaseMatchingString(existingFollowerId),
            UserTestUtilities.ValidName,
            existingFollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            null!,
            existingFollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            string.Empty,
            existingFollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            existingFollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidName),
            existingFollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            null!,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            string.Empty,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetNonCaseMatchingString(existingFollowingId),
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            existingFollowingId,
            null!,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            existingFollowingId,
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
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            existingFollowingId,
            SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            existingFollowingId,
            SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidName),
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            UserTestUtilities.ValidName,
            existingFollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollowId &&
                                                                    m.FollowerId == existingFollowerId &&
                                                                    m.FollowerName == UserTestUtilities.ValidName &&
                                                                    m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == UserTestUtilities.ValidName &&
                                                                    m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
