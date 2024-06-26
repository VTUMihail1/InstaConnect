﻿namespace InstaConnect.Shared.Business.Contracts.Users;

public class UserUpdatedEvent
{
    public string Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
