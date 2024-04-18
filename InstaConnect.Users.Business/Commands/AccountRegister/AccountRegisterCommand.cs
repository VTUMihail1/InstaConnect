﻿using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.AccountRegister
{
    public class AccountRegisterCommand : ICommand
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}