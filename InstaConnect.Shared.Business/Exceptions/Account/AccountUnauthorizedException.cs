using InstaConnect.Shared.Business.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Shared.Business.Exceptions.Account;

public class AccountUnauthorizedException : UnauthorizedException
{
    private const string ERROR_MESSAGE = "Current user is not authenticated";

    public AccountUnauthorizedException() : base(ERROR_MESSAGE)
    {
    }

    public AccountUnauthorizedException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
