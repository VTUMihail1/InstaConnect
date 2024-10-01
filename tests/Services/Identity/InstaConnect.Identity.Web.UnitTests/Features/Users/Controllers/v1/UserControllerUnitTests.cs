using System.Net;
using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.ConfirmUserEmail;
using InstaConnect.Identity.Business.Features.Users.Commands.DeleteCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Commands.DeleteUserById;
using InstaConnect.Identity.Business.Features.Users.Commands.EditCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Commands.LoginUser;
using InstaConnect.Identity.Business.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Business.Features.Users.Commands.ResendUserEmailConfirmation;
using InstaConnect.Identity.Business.Features.Users.Commands.ResetUserPassword;
using InstaConnect.Identity.Business.Features.Users.Commands.SendUserPasswordReset;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllUsers;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUserDetailed;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserById;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserByName;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserDetailedById;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Web.Features.Users.Controllers.v1;
using InstaConnect.Identity.Web.Features.Users.Models.Requests;
using InstaConnect.Identity.Web.Features.Users.Models.Responses;
using InstaConnect.Identity.Web.UnitTests.Features.Users.Utilities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Identity.Web.UnitTests.Features.Users.Controllers.v1;
public class UserControllerUnitTests : BaseUserUnitTest
{
    private readonly UserController _userController;

    public UserControllerUnitTests()
    {
        _userController = new(
            InstaConnectMapper,
            InstaConnectSender,
            CurrentUserContext);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllUsersRequest()
        {
            FirstName = UserTestUtilities.ValidFirstName,
            LastName = UserTestUtilities.ValidLastName,
            UserName = UserTestUtilities.ValidName,
            SortOrder = UserTestUtilities.ValidSortOrderProperty,
            SortPropertyName = UserTestUtilities.ValidSortPropertyName,
            Page = UserTestUtilities.ValidPageValue,
            PageSize = UserTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _userController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUserPaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllUsersRequest()
        {
            FirstName = UserTestUtilities.ValidFirstName,
            LastName = UserTestUtilities.ValidLastName,
            UserName = UserTestUtilities.ValidName,
            SortOrder = UserTestUtilities.ValidSortOrderProperty,
            SortPropertyName = UserTestUtilities.ValidSortPropertyName,
            Page = UserTestUtilities.ValidPageValue,
            PageSize = UserTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _userController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == UserTestUtilities.ValidId &&
                                                                 m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                 m.LastName == UserTestUtilities.ValidLastName &&
                                                                 m.UserName == UserTestUtilities.ValidName &&
                                                                 m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                              mc.Page == UserTestUtilities.ValidPageValue &&
                                                              mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                              mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllUsersRequest()
        {
            FirstName = UserTestUtilities.ValidFirstName,
            LastName = UserTestUtilities.ValidLastName,
            UserName = UserTestUtilities.ValidName,
            SortOrder = UserTestUtilities.ValidSortOrderProperty,
            SortPropertyName = UserTestUtilities.ValidSortPropertyName,
            Page = UserTestUtilities.ValidPageValue,
            PageSize = UserTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _userController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllUsersQuery>(m =>
                  m.FirstName == UserTestUtilities.ValidFirstName &&
                  m.LastName == UserTestUtilities.ValidLastName &&
                  m.UserName == UserTestUtilities.ValidName &&
                  m.SortOrder == UserTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == UserTestUtilities.ValidSortPropertyName &&
                  m.Page == UserTestUtilities.ValidPageValue &&
                  m.PageSize == UserTestUtilities.ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserByIdRequest()
        {
            Id = UserTestUtilities.ValidId
        };

        // Act
        var response = await _userController.GetByIdAsync(request, CancellationToken);

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
        var request = new GetUserByIdRequest()
        {
            Id = UserTestUtilities.ValidId
        };

        // Act
        var response = await _userController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserQueryResponse>(m => m.Id == UserTestUtilities.ValidId &&
                                           m.FirstName == UserTestUtilities.ValidFirstName &&
                                           m.LastName == UserTestUtilities.ValidLastName &&
                                           m.UserName == UserTestUtilities.ValidName &&
                                           m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserByIdRequest()
        {
            Id = UserTestUtilities.ValidId
        };

        // Act
        await _userController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetUserByIdQuery>(m => m.Id == UserTestUtilities.ValidId), CancellationToken);
    }

    [Fact]
    public async Task GetDetailedByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserDetailedByIdRequest()
        {
            Id = UserTestUtilities.ValidId
        };

        // Act
        var response = await _userController.GetDetailedByIdAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetDetailedByIdAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserDetailedByIdRequest()
        {
            Id = UserTestUtilities.ValidId
        };

        // Act
        var response = await _userController.GetDetailedByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserDetailedQueryResponse>(m => m.Id == UserTestUtilities.ValidId &&
                                           m.FirstName == UserTestUtilities.ValidFirstName &&
                                           m.LastName == UserTestUtilities.ValidLastName &&
                                           m.UserName == UserTestUtilities.ValidName &&
                                           m.Email == UserTestUtilities.ValidEmail &&
                                           m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetDetailedByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserDetailedByIdRequest()
        {
            Id = UserTestUtilities.ValidId
        };

        // Act
        await _userController.GetDetailedByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetUserDetailedByIdQuery>(m => m.Id == UserTestUtilities.ValidId), CancellationToken);
    }

    [Fact]
    public async Task GetByNameAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserByNameRequest()
        {
            UserName = UserTestUtilities.ValidName
        };

        // Act
        var response = await _userController.GetByNameAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetByNameAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserByNameRequest()
        {
            UserName = UserTestUtilities.ValidName
        };

        // Act
        var response = await _userController.GetByNameAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserQueryResponse>(m => m.Id == UserTestUtilities.ValidId &&
                                           m.FirstName == UserTestUtilities.ValidFirstName &&
                                           m.LastName == UserTestUtilities.ValidLastName &&
                                           m.UserName == UserTestUtilities.ValidName &&
                                           m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetByNameAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserByNameRequest()
        {
            UserName = UserTestUtilities.ValidName
        };

        // Act
        await _userController.GetByNameAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetUserByNameQuery>(m => m.UserName == UserTestUtilities.ValidName), CancellationToken);
    }

    [Fact]
    public async Task GetCurrentAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _userController.GetCurrentAsync(CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetCurrentAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Act
        var response = await _userController.GetCurrentAsync(CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserQueryResponse>(m => m.Id == UserTestUtilities.ValidId &&
                                           m.FirstName == UserTestUtilities.ValidFirstName &&
                                           m.LastName == UserTestUtilities.ValidLastName &&
                                           m.UserName == UserTestUtilities.ValidName &&
                                           m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetCurrentAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Act
        await _userController.GetCurrentAsync(CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Any<GetCurrentUserQuery>(), CancellationToken);
    }

    [Fact]
    public async Task GetCurrentAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Act
        await _userController.GetCurrentAsync(CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task GetCurrentDetailedAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _userController.GetCurrentDetailedAsync(CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetCurrentDetailedAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Act
        var response = await _userController.GetCurrentDetailedAsync(CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserDetailedQueryResponse>(m => m.Id == UserTestUtilities.ValidId &&
                                           m.FirstName == UserTestUtilities.ValidFirstName &&
                                           m.LastName == UserTestUtilities.ValidLastName &&
                                           m.UserName == UserTestUtilities.ValidName &&
                                           m.Email == UserTestUtilities.ValidEmail &&
                                           m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetCurrentDetailedAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Act
        await _userController.GetCurrentDetailedAsync(CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Any<GetCurrentUserDetailedQuery>(), CancellationToken);
    }

    [Fact]
    public async Task GetCurrentDetailedAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Act
        await _userController.GetCurrentDetailedAsync(CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new RegisterUserRequest()
        {
            RegisterUserBindingModel = new(
                UserTestUtilities.ValidName,
                UserTestUtilities.ValidEmail,
                UserTestUtilities.ValidPassword,
                UserTestUtilities.ValidPassword,
                UserTestUtilities.ValidFirstName,
                UserTestUtilities.ValidLastName,
                UserTestUtilities.ValidFormFile)
        };

        // Act
        var response = await _userController.RegisterAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new RegisterUserRequest()
        {
            RegisterUserBindingModel = new(
                UserTestUtilities.ValidName,
                UserTestUtilities.ValidEmail,
                UserTestUtilities.ValidPassword,
                UserTestUtilities.ValidPassword,
                UserTestUtilities.ValidFirstName,
                UserTestUtilities.ValidLastName,
                UserTestUtilities.ValidFormFile)
        };

        // Act
        var response = await _userController.RegisterAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserCommandResponse>(m => m.Id == UserTestUtilities.ValidId);
    }

    [Fact]
    public async Task RegisterAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new RegisterUserRequest()
        {
            RegisterUserBindingModel = new(
                UserTestUtilities.ValidName,
                UserTestUtilities.ValidEmail,
                UserTestUtilities.ValidPassword,
                UserTestUtilities.ValidPassword,
                UserTestUtilities.ValidFirstName,
                UserTestUtilities.ValidLastName,
                UserTestUtilities.ValidFormFile)
        };

        // Act
        await _userController.RegisterAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<RegisterUserCommand>(m => m.Email == UserTestUtilities.ValidEmail &&
                                                                m.Password == UserTestUtilities.ValidPassword &&
                                                                m.ConfirmPassword == UserTestUtilities.ValidPassword &&
                                                                m.UserName == UserTestUtilities.ValidName &&
                                                                m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                m.LastName == UserTestUtilities.ValidLastName &&
                                                                m.ProfileImage == UserTestUtilities.ValidFormFile), CancellationToken);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new EditCurrentUserRequest()
        {
            EditCurrentUserBindingModel = new(
                UserTestUtilities.ValidName,
                UserTestUtilities.ValidFirstName,
                UserTestUtilities.ValidLastName,
                UserTestUtilities.ValidFormFile)
        };

        // Act
        var response = await _userController.EditCurrentAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new EditCurrentUserRequest()
        {
            EditCurrentUserBindingModel = new(
                UserTestUtilities.ValidName,
                UserTestUtilities.ValidFirstName,
                UserTestUtilities.ValidLastName,
                UserTestUtilities.ValidFormFile)
        };

        // Act
        var response = await _userController.EditCurrentAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserCommandResponse>(m => m.Id == UserTestUtilities.ValidId);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new EditCurrentUserRequest()
        {
            EditCurrentUserBindingModel = new(
                UserTestUtilities.ValidName,
                UserTestUtilities.ValidFirstName,
                UserTestUtilities.ValidLastName,
                UserTestUtilities.ValidFormFile)
        };

        // Act
        await _userController.EditCurrentAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<EditCurrentUserCommand>(m => m.CurrentUserId == UserTestUtilities.ValidId &&
                                                                m.UserName == UserTestUtilities.ValidName &&
                                                                m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                m.LastName == UserTestUtilities.ValidLastName &&
                                                                m.ProfileImage == UserTestUtilities.ValidFormFile), CancellationToken);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new EditCurrentUserRequest()
        {
            EditCurrentUserBindingModel = new(
                UserTestUtilities.ValidName,
                UserTestUtilities.ValidFirstName,
                UserTestUtilities.ValidLastName,
                UserTestUtilities.ValidFormFile)
        };

        // Act
        await _userController.EditCurrentAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new LoginUserRequest()
        {
            LoginUserBindingModel = new(
                UserTestUtilities.ValidEmail,
                UserTestUtilities.ValidPassword)
        };

        // Act
        var response = await _userController.LoginAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new LoginUserRequest()
        {
            LoginUserBindingModel = new(
                UserTestUtilities.ValidEmail,
                UserTestUtilities.ValidPassword)
        };

        // Act
        var response = await _userController.LoginAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserTokenCommandResponse>(m => m.Value == UserTestUtilities.ValidAccessTokenValue &&
                                                     m.ValidUntil == UserTestUtilities.ValidUntil);
    }

    [Fact]
    public async Task LoginAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new LoginUserRequest()
        {
            LoginUserBindingModel = new(
                UserTestUtilities.ValidEmail,
                UserTestUtilities.ValidPassword)
        };

        // Act
        await _userController.LoginAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<LoginUserCommand>(m => m.Email == UserTestUtilities.ValidEmail &&
                                                          m.Password == UserTestUtilities.ValidPassword), CancellationToken);
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeleteUserByIdRequest()
        {
            Id = UserTestUtilities.ValidId
        };

        // Act
        var response = await _userController.DeleteByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeleteUserByIdRequest()
        {
            Id = UserTestUtilities.ValidId
        };

        // Act
        var response = await _userController.DeleteByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<DeleteUserByIdCommand>(m => m.Id == UserTestUtilities.ValidId), CancellationToken);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _userController.DeleteCurrentAsync(CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Act
        var response = await _userController.DeleteCurrentAsync(CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<DeleteCurrentUserCommand>(m => m.CurrentUserId == UserTestUtilities.ValidId), CancellationToken);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Act
        var response = await _userController.DeleteCurrentAsync(CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task ConfirmEmailAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new ConfirmUserEmailRequest()
        {
            Token = UserTestUtilities.ValidEmailConfirmationTokenValue,
            UserId = UserTestUtilities.ValidId
        };

        // Act
        var response = await _userController.ConfirmEmailAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task ConfirmEmailAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new ConfirmUserEmailRequest()
        {
            Token = UserTestUtilities.ValidEmailConfirmationTokenValue,
            UserId = UserTestUtilities.ValidId
        };

        // Act
        var response = await _userController.ConfirmEmailAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<ConfirmUserEmailCommand>(m => m.Token == UserTestUtilities.ValidEmailConfirmationTokenValue &&
                                                                 m.UserId == UserTestUtilities.ValidId), CancellationToken);
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new ResetUserPasswordRequest()
        {
            Token = UserTestUtilities.ValidEmailConfirmationTokenValue,
            UserId = UserTestUtilities.ValidId,
            ResetUserPasswordBindingModel = new(
                UserTestUtilities.ValidPassword,
                UserTestUtilities.ValidPassword)
        };

        // Act
        var response = await _userController.ResetPasswordAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new ResetUserPasswordRequest()
        {
            Token = UserTestUtilities.ValidEmailConfirmationTokenValue,
            UserId = UserTestUtilities.ValidId,
            ResetUserPasswordBindingModel = new(
                UserTestUtilities.ValidPassword,
                UserTestUtilities.ValidPassword)
        };

        // Act
        var response = await _userController.ResetPasswordAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<ResetUserPasswordCommand>(m => m.Token == UserTestUtilities.ValidEmailConfirmationTokenValue &&
                                                                 m.UserId == UserTestUtilities.ValidId &&
                                                                 m.Password == UserTestUtilities.ValidPassword &&
                                                                 m.ConfirmPassword == UserTestUtilities.ValidPassword), CancellationToken);
    }

    [Fact]
    public async Task ResendConfirmEmailAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new ResendUserConfirmEmailRequest()
        {
            Email = UserTestUtilities.ValidEmail
        };

        // Act
        var response = await _userController.ResendConfirmEmailAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task ResendConfirmEmailAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new ResendUserConfirmEmailRequest()
        {
            Email = UserTestUtilities.ValidEmail
        };

        // Act
        var response = await _userController.ResendConfirmEmailAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<ResendUserEmailConfirmationCommand>(m => m.Email == UserTestUtilities.ValidEmail), CancellationToken);
    }

    [Fact]
    public async Task SendResetPasswordAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new SendUserPasswordResetRequest()
        {
            Email = UserTestUtilities.ValidEmail
        };

        // Act
        var response = await _userController.SendResetPasswordAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task SendResetPasswordAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new SendUserPasswordResetRequest()
        {
            Email = UserTestUtilities.ValidEmail
        };

        // Act
        var response = await _userController.SendResetPasswordAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<SendUserPasswordResetCommand>(m => m.Email == UserTestUtilities.ValidEmail), CancellationToken);
    }
}
