using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record GetUserByIdQuery(UserId Id)
    : IIncludableQuery<UserIncludeProperty>
{
    public CommonIncludeQuery<UserIncludeProperty>? Include { get; private set; }

    public GetUserByIdQuery AddInclude(CommonIncludeQuery<UserIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
