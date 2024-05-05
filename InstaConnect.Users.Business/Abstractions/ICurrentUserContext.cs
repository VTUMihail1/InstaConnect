using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Abstractions
{
    public interface ICurrentUserContext
    {
        string? GetUsedId();
    }
}