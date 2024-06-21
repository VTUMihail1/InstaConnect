﻿using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Users.Business.Commands.Account.ConfirmAccountEmail;

public class ConfirmAccountEmailCommand : ICommand
{
    public string UserId { get; set; }

    public string Token { get; set; }
}
