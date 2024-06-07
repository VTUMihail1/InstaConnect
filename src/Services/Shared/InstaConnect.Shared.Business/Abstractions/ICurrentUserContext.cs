using InstaConnect.Shared.Business.Models.Responses;

namespace InstaConnect.Shared.Business.Abstractions;

public interface ICurrentUserContext
{
    CurrentUserDetails GetCurrentUserDetails();
}
