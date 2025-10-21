namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record GetPostLikeByIdQuery(string Id, string UserId)
{
    public PostLikeIncludeQuery? Include { get; private set; }

    public GetPostLikeByIdQuery AddInclude(PostLikeIncludeQuery include)
    {
        Include = include;

        return this;
    }
}
