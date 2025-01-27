using System.Net;
using FluentAssertions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Models;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Controllers.v1;

public class GetAllFollowsFunctionalTests : BaseFollowFunctionalTest
{
    public GetAllFollowsFunctionalTests(FollowsFunctionalTestWebAppFactory followsFunctionalTestWebAppFactory) : base(followsFunctionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowerIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = SharedTestUtilities.GetString(length),
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowerNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = SharedTestUtilities.GetString(length),
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = SharedTestUtilities.GetString(length),
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowingNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollow.FollowingId,
            FollowingName = SharedTestUtilities.GetString(length),
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowDoesNotContainProperty()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.InvalidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.SORT_PROPERTY_NAME_MIN_LENGTH - 1)]
    [InlineData(SharedBusinessConfigurations.SORT_PROPERTY_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = SharedTestUtilities.GetString(length),
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = value,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MAX_VALUE + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = value
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenValidRequest()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldOkStatusCodeResponse_WhenRequestIsValidAndFollowerNameCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldOkStatusCodeResponse_WhenRequestIsValidAndFollowerNameIsNotFull()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidName),
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldOkStatusCodeResponse_WhenRequestIsValidAndFollowingIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldOkStatusCodeResponse_WhenRequestIsValidAndFollowingNameCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollow.FollowingId,
            FollowingName = SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldOkStatusCodeResponse_WhenRequestIsValidAndFollowingNameIsNotFull()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollow.FollowingId,
            FollowingName = SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidName),
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldOkStatusCodeResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var request = new GetAllFollowsClientRequest();

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValidAndFollowerNameCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollow.Id &&
                                                               m.FollowerId == existingFollow.FollowerId &&
                                                               m.FollowerName == UserTestUtilities.ValidName &&
                                                               m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.FollowingId == existingFollow.FollowingId &&
                                                               m.FollowingName == UserTestUtilities.ValidName &&
                                                               m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidName),
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollow.Id &&
                                                               m.FollowerId == existingFollow.FollowerId &&
                                                               m.FollowerName == UserTestUtilities.ValidName &&
                                                               m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.FollowingId == existingFollow.FollowingId &&
                                                               m.FollowingName == UserTestUtilities.ValidName &&
                                                               m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            FollowingId = existingFollow.FollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollow.Id &&
                                                               m.FollowerId == existingFollow.FollowerId &&
                                                               m.FollowerName == UserTestUtilities.ValidName &&
                                                               m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.FollowingId == existingFollow.FollowingId &&
                                                               m.FollowingName == UserTestUtilities.ValidName &&
                                                               m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollow.FollowingId,
            FollowingName = SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest(getAllFollowsRequest);

        // Act
        var response = await FollowsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollow.Id &&
                                                               m.FollowerId == existingFollow.FollowerId &&
                                                               m.FollowerName == UserTestUtilities.ValidName &&
                                                               m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.FollowingId == existingFollow.FollowingId &&
                                                               m.FollowingName == UserTestUtilities.ValidName &&
                                                               m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var getAllFollowsRequest = new GetAllFollowsRequest
        {
            FollowerId = existingFollow.FollowerId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollow.FollowingId,
            FollowingName = SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidName),
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue
        };
        var request = new GetAllFollowsClientRequest();

        // Act
        var response = await FollowsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollow.Id &&
                                                               m.FollowerId == existingFollow.FollowerId &&
                                                               m.FollowerName == UserTestUtilities.ValidName &&
                                                               m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.FollowingId == existingFollow.FollowingId &&
                                                               m.FollowingName == UserTestUtilities.ValidName &&
                                                               m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var request = new GetAllFollowsClientRequest();

        // Act
        var response = await FollowsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollow.Id &&
                                                               m.FollowerId == existingFollow.FollowerId &&
                                                               m.FollowerName == UserTestUtilities.ValidName &&
                                                               m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.FollowingId == existingFollow.FollowingId &&
                                                               m.FollowingName == UserTestUtilities.ValidName &&
                                                               m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                               mc.Page == FollowTestUtilities.ValidPageValue &&
                                                               mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }
}
