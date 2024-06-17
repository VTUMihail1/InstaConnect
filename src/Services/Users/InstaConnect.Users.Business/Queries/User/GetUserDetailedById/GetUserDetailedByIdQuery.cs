﻿using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Queries.User.GetUserDetailedById;

public class GetUserDetailedByIdQuery : IQuery<UserDetailedViewModel>
{
    public string Id { get; set; }
}
