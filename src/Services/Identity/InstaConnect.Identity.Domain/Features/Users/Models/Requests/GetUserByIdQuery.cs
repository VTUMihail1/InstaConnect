namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record GetUserByIdQuery(UserId Id)
{
    public UserIncludeQuery? Include { get; private set; }

    public GetUserByIdQuery AddInclude(UserIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
