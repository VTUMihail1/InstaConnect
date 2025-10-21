using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

public record GetUserByIdQuery(string Id)
{
    public UserIncludeQuery? Include { get; private set; }

    public GetUserByIdQuery AddInclude(UserIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
