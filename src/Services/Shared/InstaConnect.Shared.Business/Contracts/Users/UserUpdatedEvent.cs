namespace InstaConnect.Shared.Business.Contracts.Users;

public class UserUpdatedEvent
{
    public string Id { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
}
