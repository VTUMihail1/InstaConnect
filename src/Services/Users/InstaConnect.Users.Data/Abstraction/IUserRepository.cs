﻿using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Users.Data.Models.Entities;

namespace InstaConnect.Users.Data.Abstraction;

/// <summary>
/// Represents a repository interface specifically for managing users, inheriting from the generic repository for entities of type <see cref="User"/>.
/// </summary>
public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);

    Task ConfirmEmailAsync(string id, CancellationToken cancellationToken);

    Task ResetPasswordAsync(string id, string passwordHash, CancellationToken cancellationToken);
}