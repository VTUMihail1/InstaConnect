using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface IUserFactory
{
    public User Create(
        Name name,
        string firstName,
        string lastName,
        Email email,
        string passwordHash);
}
