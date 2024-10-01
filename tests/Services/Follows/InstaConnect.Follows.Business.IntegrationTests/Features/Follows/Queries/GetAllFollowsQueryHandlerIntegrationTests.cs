using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Business.IntegrationTests.Features.Follows.Utilities;
using InstaConnect.Follows.Business.IntegrationTests.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Business.IntegrationTests.Features.Follows.Queries;

public class GetAllFollowsQueryHandlerIntegrationTests : BaseFollowIntegrationTest
{
    public GetAllFollowsQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            SharedTestUtilities.GetString(length),
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            SharedTestUtilities.GetString(length),
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            FollowTestUtilities.ValidUserName,
            SharedTestUtilities.GetString(length),
            FollowTestUtilities.ValidUserName,
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
    [InlineData(FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFollowingNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var query = new GetAllFollowsQuery(
            existingFollowerId,
            FollowTestUtilities.ValidUserName,
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            SharedTestUtilities.GetNonCaseMatchingString(FollowTestUtilities.ValidUserName),
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            SharedTestUtilities.GetHalfStartString(FollowTestUtilities.ValidUserName),
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            FollowTestUtilities.ValidUserName,
            null!,
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            FollowTestUtilities.ValidUserName,
            string.Empty,
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            FollowTestUtilities.ValidUserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingFollowingId),
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            SharedTestUtilities.GetNonCaseMatchingString(FollowTestUtilities.ValidUserName),
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            SharedTestUtilities.GetHalfStartString(FollowTestUtilities.ValidUserName),
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
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
                                                                    m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                    m.FollowingId == existingFollowingId &&
                                                                    m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                    m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
