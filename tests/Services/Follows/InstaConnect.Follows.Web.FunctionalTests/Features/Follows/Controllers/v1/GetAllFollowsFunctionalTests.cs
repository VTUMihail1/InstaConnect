using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Follows.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Controllers.v1;

public class GetAllFollowsFunctionalTests : BaseFollowFunctionalTest
{
    public GetAllFollowsFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowerIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new GetAllFollowsRequest
        {
            FollowerId = SharedTestUtilities.GetString(length),
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowerNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = SharedTestUtilities.GetString(length),
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = SharedTestUtilities.GetString(length),
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowingNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = existingFollowingId,
            FollowingName = SharedTestUtilities.GetString(length),
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowDoesNotContainProperty()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.InvalidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.SORT_PROPERTY_NAME_MIN_LENGTH - 1)]
    [InlineData(SharedBusinessConfigurations.SORT_PROPERTY_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = SharedTestUtilities.GetString(length),
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = value,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MAX_VALUE + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = value
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenValidRequest()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldOkStatusCodeResponse_WhenRequestIsValidAndFollowerNameCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = SharedTestUtilities.GetNonCaseMatchingString(FollowTestUtilities.ValidUserName),
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldOkStatusCodeResponse_WhenRequestIsValidAndFollowerNameIsNotFull()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = SharedTestUtilities.GetHalfStartString(FollowTestUtilities.ValidUserName),
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldOkStatusCodeResponse_WhenRequestIsValidAndFollowingIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = SharedTestUtilities.GetNonCaseMatchingString(FollowTestUtilities.ValidUserName),
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldOkStatusCodeResponse_WhenRequestIsValidAndFollowingNameCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = existingFollowingId,
            FollowingName = SharedTestUtilities.GetNonCaseMatchingString(FollowTestUtilities.ValidUserName),
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldOkStatusCodeResponse_WhenRequestIsValidAndFollowingNameIsNotFull()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = existingFollowingId,
            FollowingName = SharedTestUtilities.GetHalfStartString(FollowTestUtilities.ValidUserName),
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldOkStatusCodeResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync();

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValidAndFollowerNameCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = SharedTestUtilities.GetNonCaseMatchingString(FollowTestUtilities.ValidUserName),
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllAsync(request);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
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
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValidAndFollowerNameIsNotFull()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = SharedTestUtilities.GetHalfStartString(FollowTestUtilities.ValidUserName),
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllAsync(request);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
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
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValidAndFollowingIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = SharedTestUtilities.GetNonCaseMatchingString(FollowTestUtilities.ValidUserName),
            FollowingId = existingFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllAsync(request);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
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
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValidAndFollowingNameCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = existingFollowingId,
            FollowingName = SharedTestUtilities.GetNonCaseMatchingString(FollowTestUtilities.ValidUserName),
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllAsync(request);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
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
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValidAndFollowingNameIsNotFull()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetAllFollowsRequest
        {
            FollowerId = existingFollowerId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = existingFollowingId,
            FollowingName = SharedTestUtilities.GetHalfStartString(FollowTestUtilities.ValidUserName),
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };

        // Act
        var response = await FollowsClient.GetAllAsync(request);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
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
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        // Act

        var response = await FollowsClient.GetAllAsync();

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
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
