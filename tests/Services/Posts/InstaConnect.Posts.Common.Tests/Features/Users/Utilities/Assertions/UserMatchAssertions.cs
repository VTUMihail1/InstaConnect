using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Update;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Users.Application.Features.Users.Commands.Add;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;

public static class UserMatchAssertions
{
    public static void ShouldSatisfy(this AddUserCommandResponse response, User user)
    {
        response.ShouldSatisfy(u => u.Id == user.Id &&
                                    u.CreatedAt == user.CreatedAt &&
                                    u.UpdatedAt == user.UpdatedAt);
    }

    public static void ShouldSatisfy(this UpdateUserCommandResponse response, User user)
    {
        response.ShouldSatisfy(u => u.Id == user.Id &&
                                    u.CreatedAt == user.CreatedAt &&
                                    u.UpdatedAt == user.UpdatedAt);
    }

    public static void ShouldSatisfy(this User user, AddUserCommandRequest request)
    {
        user.ShouldSatisfy(u => u.Id == request.Id &&
                                u.Name == request.Name &&
                                u.FirstName == request.FirstName &&
                                u.LastName == request.LastName &&
                                u.Email == request.Email &&
                                u.ProfileImage == request.ProfileImage);
    }

    public static void ShouldSatisfy(this User user, UpdateUserCommandRequest request)
    {
        user.ShouldSatisfy(u => u.Id == request.Id &&
                                u.Name == request.Name &&
                                u.FirstName == request.FirstName &&
                                u.LastName == request.LastName &&
                                u.Email == request.Email &&
                                u.ProfileImage == request.ProfileImage);
    }

    public static void ShouldSatisfy(this User user, UserAddedEventRequest request)
    {
        user.ShouldSatisfy(u => u.Id == request.Id &&
                                u.Name == request.Name &&
                                u.FirstName == request.FirstName &&
                                u.LastName == request.LastName &&
                                u.Email == request.Email &&
                                u.ProfileImage == request.ProfileImage);
    }

    public static void ShouldSatisfy(this User user, UserUpdatedEventRequest request)
    {
        user.ShouldSatisfy(u => u.Id == request.Id &&
                                u.Name == request.Name &&
                                u.FirstName == request.FirstName &&
                                u.LastName == request.LastName &&
                                u.Email == request.Email &&
                                u.ProfileImage == request.ProfileImage);
    }

    public static void ShouldSatisfyUserNotFound(
        this ProblemDetails problemDetails,
        string id)
    {
        problemDetails.ShouldSatisfyNotFound(UserExceptionErrorMessages.GetNotFoundMessage(id));
    }
}
