using InstaConnect.Shared.Business.Models.Users;

namespace InstaConnect.Shared.Web.Abstractions;

public interface ICurrentUserContext
{
    CurrentUserModel GetCurrentUser();
}
