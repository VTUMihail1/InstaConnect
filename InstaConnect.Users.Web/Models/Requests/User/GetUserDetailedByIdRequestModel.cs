﻿using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.User
{
    public class GetUserDetailedByIdRequestModel
    {
        [FromRoute]
        public string Id { get; set; }
    }
}
