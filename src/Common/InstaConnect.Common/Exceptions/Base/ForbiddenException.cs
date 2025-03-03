﻿namespace InstaConnect.Shared.Common.Exceptions.Base;

public class ForbiddenException : BaseException
{
    public ForbiddenException(string message) : base(message, InstaConnectStatusCode.Forbidden)
    {
    }

    public ForbiddenException(string message, Exception exception) : base(message, exception, InstaConnectStatusCode.Forbidden)
    {
    }
}
