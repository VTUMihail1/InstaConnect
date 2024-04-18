﻿using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Business.Models.Exceptions.User
{
    public class UserNotFoundException : UserException
    {
        private const string ERROR_MESSAGE = "User not found";

        public UserNotFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}