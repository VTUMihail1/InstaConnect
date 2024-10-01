using System.Net;
using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Business.Features.Follows.Commands.DeleteFollow;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Web.Features.Follows.Controllers.v1;
using InstaConnect.Follows.Web.Features.Follows.Models.Binding;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Follows.Web.UnitTests.Features.Follows.Utilities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Follows.Web.UnitTests.Features.Follows.Controllers.v1;
public class FollowControllerUnitTests : BaseFollowUnitTest
{
    private readonly FollowController _followController;

    public FollowControllerUnitTests()
    {
        _followController = new(
            InstaConnectMapper,
            InstaConnectSender,
            CurrentUserContext);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFollowsRequest()
        {
            FollowerId = FollowTestUtilities.ValidCurrentUserId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = FollowTestUtilities.ValidCurrentUserId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _followController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFollowsRequest()
        {
            FollowerId = FollowTestUtilities.ValidCurrentUserId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = FollowTestUtilities.ValidCurrentUserId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _followController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == FollowTestUtilities.ValidId &&
                                                                 m.FollowerId == FollowTestUtilities.ValidCurrentUserId &&
                                                                 m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                 m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                                 m.FollowingId == FollowTestUtilities.ValidFollowingId &&
                                                                 m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                 m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
                                                              mc.Page == FollowTestUtilities.ValidPageValue &&
                                                              mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                              mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFollowsRequest()
        {
            FollowerId = FollowTestUtilities.ValidCurrentUserId,
            FollowerName = FollowTestUtilities.ValidUserName,
            FollowingId = FollowTestUtilities.ValidFollowingId,
            FollowingName = FollowTestUtilities.ValidUserName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _followController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllFollowsQuery>(m =>
                  m.FollowerId == FollowTestUtilities.ValidCurrentUserId &&
                  m.FollowerName == FollowTestUtilities.ValidUserName &&
                  m.FollowingId == FollowTestUtilities.ValidFollowingId &&
                  m.FollowingName == FollowTestUtilities.ValidUserName &&
                  m.SortOrder == FollowTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == FollowTestUtilities.ValidSortPropertyName &&
                  m.Page == FollowTestUtilities.ValidPageValue &&
                  m.PageSize == FollowTestUtilities.ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetFollowByIdRequest()
        {
            Id = FollowTestUtilities.ValidId
        };

        // Act
        var response = await _followController.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetFollowByIdRequest()
        {
            Id = FollowTestUtilities.ValidId
        };

        // Act
        var response = await _followController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<FollowQueryResponse>(m => m.Id == FollowTestUtilities.ValidId &&
                                                 m.FollowerId == FollowTestUtilities.ValidCurrentUserId &&
                                                 m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                 m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                 m.FollowingId == FollowTestUtilities.ValidFollowingId &&
                                                 m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                 m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetFollowByIdRequest()
        {
            Id = FollowTestUtilities.ValidId
        };

        // Act
        await _followController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetFollowByIdQuery>(m => m.Id == FollowTestUtilities.ValidId), CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenFollowIsValid()
    {
        // Arrange
        var request = new AddFollowRequest()
        {
            AddFollowBindingModel = new AddFollowBindingModel(FollowTestUtilities.ValidFollowingId)
        };

        // Act
        var response = await _followController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task AddAsync_ShouldReturnFollowViewModel_WhenFollowIsValid()
    {
        // Arrange
        var request = new AddFollowRequest()
        {
            AddFollowBindingModel = new AddFollowBindingModel(FollowTestUtilities.ValidFollowingId)
        };

        // Act
        var response = await _followController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<FollowCommandResponse>(m => m.Id == FollowTestUtilities.ValidId);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenFollowIsValid()
    {
        // Arrange
        var request = new AddFollowRequest()
        {
            AddFollowBindingModel = new AddFollowBindingModel(FollowTestUtilities.ValidFollowingId)
        };

        // Act
        await _followController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddFollowCommand>(m => m.CurrentUserId == FollowTestUtilities.ValidCurrentUserId &&
                                                     m.FollowingId == FollowTestUtilities.ValidFollowingId),
                                                     CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheCurrentUserContext_WhenFollowIsValid()
    {
        // Arrange
        var request = new AddFollowRequest()
        {
            AddFollowBindingModel = new AddFollowBindingModel(FollowTestUtilities.ValidFollowingId)
        };

        // Act
        await _followController.AddAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenFollowIsValid()
    {
        // Arrange
        var request = new DeleteFollowRequest()
        {
            Id = FollowTestUtilities.ValidId
        };

        // Act
        var response = await _followController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenFollowIsValid()
    {
        // Arrange
        var request = new DeleteFollowRequest()
        {
            Id = FollowTestUtilities.ValidId
        };

        // Act
        await _followController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeleteFollowCommand>(m => m.Id == FollowTestUtilities.ValidId &&
                                                    m.CurrentUserId == FollowTestUtilities.ValidCurrentUserId),
                                                    CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheCurrentUserContext_WhenFollowIsValid()
    {
        // Arrange
        var request = new DeleteFollowRequest()
        {
            Id = FollowTestUtilities.ValidId
        };

        // Act
        await _followController.DeleteAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }
}
