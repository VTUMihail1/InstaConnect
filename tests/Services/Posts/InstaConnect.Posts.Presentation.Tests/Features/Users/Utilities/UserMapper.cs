using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;
public static class UserMapper
{
    public static UserQueryResponse ToFullResponse(this User user)
    {
        return new(user.Id.Id,
                   user.FirstName,
                   user.LastName,
                   user.Name.Value,
                   user.ProfileImage?.Url,
                   user.CreatedAtUtc,
                   user.UpdatedAtUtc);
    }
}
