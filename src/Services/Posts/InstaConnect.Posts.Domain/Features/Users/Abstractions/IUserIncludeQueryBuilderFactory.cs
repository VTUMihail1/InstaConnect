using InstaConnect.Users.Domain.Features.Users.Helpers;

namespace InstaConnect.Users.Domain.Features.Users.Abstractions;

public interface IUserIncludeQueryBuilderFactory
{
    UserIncludeQueryBuilder Create();
}