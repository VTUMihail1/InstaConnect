using InstaConnect.Shared.Presentation.Models.Users;

namespace InstaConnect.Shared.Presentation.Abstractions;

public interface ICurrentUserContext
{
    CurrentUserModel GetCurrentUser();
}
