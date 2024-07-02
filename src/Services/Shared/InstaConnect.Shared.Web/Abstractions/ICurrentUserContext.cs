using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Shared.Web.Abstractions;

public interface ICurrentUserContext
{
    CurrentUserModel GetCurrentUser();
}
