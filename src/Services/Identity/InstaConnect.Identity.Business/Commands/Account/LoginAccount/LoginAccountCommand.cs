﻿using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.LoginAccount;

public class LoginAccountCommand : ICommand<AccountViewModel>
{
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
