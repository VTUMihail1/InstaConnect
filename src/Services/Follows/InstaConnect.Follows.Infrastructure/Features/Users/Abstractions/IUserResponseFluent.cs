using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

public interface IUserResponseFluent : IMongoDbResponseFluent<UserResponse>;
