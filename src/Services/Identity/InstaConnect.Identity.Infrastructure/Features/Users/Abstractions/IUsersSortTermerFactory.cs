
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

public interface IUsersSortTermerFactory : ISortTermerFactory<UsersSortTerm, IUsersSortTermer, UserResponse>;
