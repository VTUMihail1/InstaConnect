using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
public static class UserEquals
{
    public static bool Matches(
        this AddUserCommandResponse response,
        User user,
        AddUserCommandRequest request)
    {
        return response.Id.Matches(user.Id);
    }

    public static bool Matches(
        this UpdateUserCommandResponse response,
        User user,
        UpdateUserCommandRequest request)
    {
        return response.Id.Matches(user.Id);
    }

    public static bool Matches(this User user, AddUserCommandRequest request)
    {
        return user.Id.Matches(request.Id) &&
               user.FirstName == request.FirstName &&
               user.LastName == request.LastName &&
               user.Name.Matches(request.Name) &&
               user.Email.Matches(request.Email) &&
               user.ProfileImage.Matches(request.ProfileImageUrl) &&
               user.CreatedAtUtc == request.CreatedAtUtc &&
               user.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this User user, UpdateUserCommandRequest request)
    {
        return user.Id.Matches(request.Id) &&
               user.FirstName == request.FirstName &&
               user.LastName == request.LastName &&
               user.Name.Matches(request.Name) &&
               user.Email.Matches(request.Email) &&
               user.ProfileImage.Matches(request.ProfileImageUrl) &&
               user.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this AddUserCommand command, AddUserCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.Email.Matches(request.Email) &&
               command.Name.Matches(request.Name) &&
               command.FirstName == request.FirstName &&
               command.LastName == request.LastName &&
               command.ProfileImage.Matches(request.ProfileImageUrl) &&
               command.CreatedAtUtc == request.CreatedAtUtc &&
               command.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this UpdateUserCommand command, UpdateUserCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.Email.Matches(request.Email) &&
               command.Name.Matches(request.Name) &&
               command.FirstName == request.FirstName &&
               command.LastName == request.LastName &&
               command.ProfileImage.Matches(request.ProfileImageUrl) &&
               command.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this DeleteUserCommand command, DeleteUserCommandRequest request)
    {
        return command.Id.Matches(request.Id);
    }

    public static bool Matches(this UserIdCommandResponse response, UserId id)
    {
        return id.Matches(response.Id);
    }

    public static bool MatchesFull(this UserQueryResponse? response, User? user)
    {
        return response != null &&
               user != null &&
               user.Id.Matches(response.Id) &&
               user.FirstName == response.FirstName &&
               user.LastName == response.LastName &&
               user.Name.Matches(response.Name) &&
               user.ProfileImage.Matches(response.ProfileImageUrl) &&
               user.CreatedAtUtc == response.CreatedAtUtc &&
               user.UpdatedAtUtc == response.UpdatedAtUtc;
    }

    public static bool MatchesCurrentUserable<TQuery, TQueryRequest>(
        this TQuery query,
        TQueryRequest request)
        where TQuery : ICurrentUserableQuery
        where TQueryRequest : ICurrentUserableQueryRequest
    {
        return query.CurrentUser.Id.Matches(request.CurrentUserId);
    }
}
