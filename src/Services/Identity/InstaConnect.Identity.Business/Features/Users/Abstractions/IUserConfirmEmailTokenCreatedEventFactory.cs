using InstaConnect.Shared.Business.Contracts.Emails;

namespace InstaConnect.Identity.Business.Features.Users.Abstractions;
public interface IUserConfirmEmailTokenCreatedEventFactory
{
    UserConfirmEmailTokenCreatedEvent GetUserConfirmEmailTokenCreatedEvent(string userId, string email, string token);
}
