
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

public interface IUsersSortTermerFactory : ISortTermerFactory<UsersSortTerm, IUsersSortTermer, UserResponse>;
