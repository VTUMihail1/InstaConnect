using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetPostByIdQuery(PostId Id)
    : IIncludableQuery<PostIncludeProperty>
{
    public CommonIncludeQuery<PostIncludeProperty>? Include { get; private set; }

    public GetPostByIdQuery AddInclude(CommonIncludeQuery<PostIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
