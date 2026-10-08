using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;

public interface IUserResponseFluent : IMongoDbResponseFluent<UserResponse>;
