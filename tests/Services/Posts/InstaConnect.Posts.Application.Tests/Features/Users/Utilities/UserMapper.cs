using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
public static class UserMapper
{
    internal static UserId ToIdResponse(
        this User user)
    {
        return user.Id;
    }

    public static UserResponse ToFullResponse(this User user)
    {
        return new(user.Id,
                   user.FirstName,
                   user.LastName,
                   user.Email,
                   user.Name,
                   user.ProfileImage,
                   user.CreatedAtUtc,
                   user.UpdatedAtUtc);
    }

    public static UserId ToResponse(
        this User user,
        AddUserCommandRequest request)
    {
        return user.ToIdResponse();
    }

    public static UserId ToResponse(
        this User user,
        UpdateUserCommandRequest request)
    {
        return user.ToIdResponse();
    }
}
