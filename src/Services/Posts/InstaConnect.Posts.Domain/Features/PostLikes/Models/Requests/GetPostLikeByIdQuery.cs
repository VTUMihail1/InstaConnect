using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record GetPostLikeByIdQuery(PostLikeId Id)
    : IIncludableQuery<PostLikeIncludeProperty>
{
    public CommonIncludeQuery<PostLikeIncludeProperty>? Include { get; private set; }

    public GetPostLikeByIdQuery AddInclude(CommonIncludeQuery<PostLikeIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
