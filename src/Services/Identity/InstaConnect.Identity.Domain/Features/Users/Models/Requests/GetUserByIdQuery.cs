namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record GetUserByIdQuery(string Id)
{
    public UserIncludeQuery? Include { get; private set; }

    public GetUserByIdQuery AddInclude(UserIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
