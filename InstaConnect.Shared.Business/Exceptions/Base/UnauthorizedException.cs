using InstaConnect.Shared.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Shared.Business.Exceptions.Base
{
    public class UnauthorizedException : BaseException
    {
        protected UnauthorizedException(string message) : base(message, InstaConnectStatusCode.Unauthorized)
        {
        }

        protected UnauthorizedException(string message, Exception exception) : base(message, exception, InstaConnectStatusCode.Unauthorized)
        {
        }
    }
}
