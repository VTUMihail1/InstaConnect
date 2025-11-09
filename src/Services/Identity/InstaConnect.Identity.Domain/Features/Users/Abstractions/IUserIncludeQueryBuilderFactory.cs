using InstaConnect.Identity.Domain.Features.Users.Helpers;

namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface IUserIncludeQueryBuilderFactory
{
    UserIncludeQueryBuilder Create();
}