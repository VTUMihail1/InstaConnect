namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetPostByIdQuery(string Id)
{
    public PostIncludeQuery? Include { get; private set; }

    public GetPostByIdQuery AddInclude(PostIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
