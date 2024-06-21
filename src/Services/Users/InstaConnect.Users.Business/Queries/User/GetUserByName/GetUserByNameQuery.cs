﻿using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Queries.User.GetUserByName;

public class GetUserByNameQuery : IQuery<UserViewModel>
{
    public string UserName { get; set; }
}
