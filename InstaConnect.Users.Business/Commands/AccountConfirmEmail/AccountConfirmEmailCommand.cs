using InstaConnect.Shared.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Users.Business.Commands.AccountConfirmEmail
{
    public class AccountConfirmEmailCommand : ICommand
    {
        public string UserId { get; set; }

        public string Token { get; set; }
    }
}
