﻿using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Common.Exceptions.User
{
    public class UserNotCurrentException : UserException
    {
        private const string ERROR_MESSAGE = "User is not current";

        public UserNotCurrentException() : base(ERROR_MESSAGE, InstaConnectStatusCode.Forbidden)
        {
        }
    }
}
