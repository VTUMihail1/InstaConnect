﻿using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Queries.GetAllUsers
{
    public class GetAllUsersQuery : CollectionDTO, IQuery<ICollection<UserViewDTO>>
    {
    }
}