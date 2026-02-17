using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;
public static class UserEquals
{
    public static bool Matches(this User user, UserAddedEventRequest request)
    {
        return user.Matches(request.User);
    }

    public static bool Matches(this User user, UserUpdatedEventRequest request)
    {
        return user.Matches(request.User);
    }

    public static bool Matches(this User user, User u)
    {
        return user.Id.Matches(u.Id.Id) &&
               user.Email.Matches(u.Email.Value) &&
               user.FirstName == u.FirstName &&
               user.LastName == u.LastName &&
               user.Name.Matches(u.Name.Value) &&
               user.ProfileImage.Matches(u.ProfileImage?.Url) &&
               user.CreatedAtUtc == u.CreatedAtUtc &&
               user.UpdatedAtUtc == u.UpdatedAtUtc;
    }

    public static bool Matches(this AddUserCommandRequest command, UserAddedEventRequest request)
    {
        return command.Id == request.User.Id &&
               command.Email == request.User.Email &&
               command.Name == request.User.Name &&
               command.FirstName == request.User.FirstName &&
               command.LastName == request.User.LastName &&
               command.ProfileImageUrl == request.User.ProfileImageUrl;
    }

    public static bool Matches(this UpdateUserCommandRequest command, UserUpdatedEventRequest request)
    {
        return command.Id == request.User.Id &&
               command.Email == request.User.Email &&
               command.Name == request.User.Name &&
               command.FirstName == request.User.FirstName &&
               command.LastName == request.User.LastName &&
               command.ProfileImageUrl == request.User.ProfileImageUrl;
    }

    public static bool Matches(this DeleteUserCommandRequest command, UserDeletedEventRequest request)
    {
        return command.Id == request.User.Id;
    }

    public static bool MatchesFull(this UserApiResponse? response, User? user)
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

    public static bool MatchesCurrentUserable<TQueryRequest, TApiRequest>(
        this TQueryRequest query,
        TApiRequest request)
        where TQueryRequest : ICurrentUserableQueryRequest
        where TApiRequest : ICurrentUserableApiRequest
    {
        return query.CurrentUserId == request.CurrentUserId;
    }
}
