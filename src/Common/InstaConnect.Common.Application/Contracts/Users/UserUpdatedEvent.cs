﻿namespace InstaConnect.Shared.Application.Contracts.Users;

public record UserUpdatedEvent(string Id, string UserName, string Email, string FirstName, string LastName, string? ProfileImage);
