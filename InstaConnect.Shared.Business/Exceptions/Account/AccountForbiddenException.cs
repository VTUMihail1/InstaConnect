using InstaConnect.Shared.Business.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Shared.Business.Exceptions.Account;

public class AccountForbiddenException : ForbiddenException
{
    private const string ERROR_MESSAGE = "Account is forbidden";

    public AccountForbiddenException() : base(ERROR_MESSAGE)
    {
    }

    public AccountForbiddenException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
