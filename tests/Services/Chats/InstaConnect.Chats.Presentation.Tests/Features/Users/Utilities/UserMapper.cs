using InstaConnect.Chats.Application.Features.Users.Models;

namespace InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;

public static class UserMapper
{
    extension(User user)
    {
        public UserQueryResponse ToFullResponse()
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
}
