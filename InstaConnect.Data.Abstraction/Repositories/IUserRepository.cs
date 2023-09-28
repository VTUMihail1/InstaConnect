﻿using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing users, inheriting from the generic repository for entities of type <see cref="User"/>.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    { }
}
