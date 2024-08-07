using System.Net;
using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Business.Features.Follows.Commands.DeleteFollow;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFilteredFollows;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
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
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
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
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
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
                                                                 m.Id == ValidId &&
                                                                 m.FollowerId == ValidCurrentUserId &&
                                                                 m.FollowerName == ValidUserName &&
                                                                 m.FollowerProfileImage == ValidUserProfileImage &&
                                                                 m.FollowingId == ValidFollowingId &&
                                                                 m.FollowingName == ValidUserName &&
                                                                 m.FollowingProfileImage == ValidUserProfileImage) &&
                                                              mc.Page == ValidPageValue &&
                                                              mc.PageSize == ValidPageSizeValue &&
                                                              mc.TotalCount == ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFollowsRequest()
        {
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var response = await _followController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllFollowsQuery>(m =>
                  m.SortOrder == ValidSortOrderProperty &&
                  m.SortPropertyName == ValidSortPropertyName &&
                  m.Page == ValidPageValue &&
                  m.PageSize == ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFollowsRequest()
        {
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        await _followController.GetAllAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFilteredFollowsRequest()
        {
            FollowerId = ValidCurrentUserId,
            FollowerName = ValidUserName,
            FollowingId = ValidCurrentUserId,
            FollowingName = ValidUserName,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var response = await _followController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnFollowPaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFilteredFollowsRequest()
        {
            FollowerId = ValidCurrentUserId,
            FollowerName = ValidUserName,
            FollowingId = ValidCurrentUserId,
            FollowingName = ValidUserName,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var response = await _followController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == ValidId &&
                                                                 m.FollowerId == ValidCurrentUserId &&
                                                                 m.FollowerName == ValidUserName &&
                                                                 m.FollowerProfileImage == ValidUserProfileImage &&
                                                                 m.FollowingId == ValidFollowingId &&
                                                                 m.FollowingName == ValidUserName &&
                                                                 m.FollowingProfileImage == ValidUserProfileImage) &&
                                                              mc.Page == ValidPageValue &&
                                                              mc.PageSize == ValidPageSizeValue &&
                                                              mc.TotalCount == ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFilteredFollowsRequest()
        {
            FollowerId = ValidCurrentUserId,
            FollowerName = ValidUserName,
            FollowingId = ValidFollowingId,
            FollowingName = ValidUserName,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var response = await _followController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllFilteredFollowsQuery>(m =>
                  m.FollowerId == ValidCurrentUserId &&
                  m.FollowerName == ValidUserName &&
                  m.FollowingId == ValidFollowingId &&
                  m.FollowingName == ValidUserName &&
                  m.SortOrder == ValidSortOrderProperty &&
                  m.SortPropertyName == ValidSortPropertyName &&
                  m.Page == ValidPageValue &&
                  m.PageSize == ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFilteredFollowsRequest()
        {
            FollowerId = ValidCurrentUserId,
            FollowerName = ValidUserName,
            FollowingId = ValidCurrentUserId,
            FollowingName = ValidUserName,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        await _followController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetFollowByIdRequest()
        {
            Id = ValidId
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
            Id = ValidId
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
            .Match<FollowQueryResponse>(m => m.Id == ValidId &&
                                                 m.FollowerId == ValidCurrentUserId &&
                                                 m.FollowerName == ValidUserName &&
                                                 m.FollowerProfileImage == ValidUserProfileImage &&
                                                 m.FollowingId == ValidFollowingId &&
                                                 m.FollowingName == ValidUserName &&
                                                 m.FollowingProfileImage == ValidUserProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetFollowByIdRequest()
        {
            Id = ValidId
        };

        // Act
        await _followController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetFollowByIdQuery>(m => m.Id == ValidId), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        var request = new GetFollowByIdRequest()
        {
            Id = ValidId
        };

        // Act
        await _followController.GetByIdAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenFollowIsValid()
    {
        // Arrange
        var request = new AddFollowRequest()
        {
            AddFollowBindingModel = new AddFollowBindingModel(ValidFollowingId)
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
            AddFollowBindingModel = new AddFollowBindingModel(ValidFollowingId)
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
            .Match<FollowCommandResponse>(m => m.Id == ValidId);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenFollowIsValid()
    {
        // Arrange
        var request = new AddFollowRequest()
        {
            AddFollowBindingModel = new AddFollowBindingModel(ValidFollowingId)
        };

        // Act
        await _followController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddFollowCommand>(m => m.CurrentUserId == ValidCurrentUserId &&
                                                     m.FollowingId == ValidFollowingId),
                                                     CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheCurrentUserContext_WhenFollowIsValid()
    {
        // Arrange
        var request = new AddFollowRequest()
        {
            AddFollowBindingModel = new AddFollowBindingModel(ValidFollowingId)
        };

        // Act
        await _followController.AddAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenFollowIsValid()
    {
        // Arrange
        var request = new DeleteFollowRequest()
        {
            Id = ValidId
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
            Id = ValidId
        };

        // Act
        await _followController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeleteFollowCommand>(m => m.Id == ValidId &&
                                                    m.CurrentUserId == ValidCurrentUserId),
                                                    CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheCurrentUserContext_WhenFollowIsValid()
    {
        // Arrange
        var request = new DeleteFollowRequest()
        {
            Id = ValidId
        };

        // Act
        await _followController.DeleteAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }
}
