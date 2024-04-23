using InstaConnect.Shared.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Shared.Business.Exceptions.Base
{
    public class ForbiddenException : BaseException
    {
        public ForbiddenException(string message) : base(message, InstaConnectStatusCode.Forbidden)
        {
        }

        public ForbiddenException(string message, Exception exception) : base(message, exception, InstaConnectStatusCode.Forbidden)
        {
        }
    }
}
