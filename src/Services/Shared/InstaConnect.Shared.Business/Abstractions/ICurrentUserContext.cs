using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.Models.Users;

namespace InstaConnect.Shared.Business.Abstractions;

public interface ICurrentUserContext
{
    CurrentUserDetails GetCurrentUserDetails();
}
