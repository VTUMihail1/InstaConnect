using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record GetUserByNameQuery(Name Name)
    : IIncludableQuery<UserIncludeProperty>
{
    public CommonIncludeQuery<UserIncludeProperty>? Include { get; private set; }

    public GetUserByNameQuery AddInclude(CommonIncludeQuery<UserIncludeProperty> include)
    {
        Include = include;

        return this;
    }
}
