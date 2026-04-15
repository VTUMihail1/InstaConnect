using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class PostLikeIncluderFactory : IPostLikeIncluderFactory
{
    private readonly IEnumerable<IPostLikeIncluder> _includers;

    public PostLikeIncluderFactory(IEnumerable<IPostLikeIncluder> includers)
    {
        _includers = includers;
    }

    public IEnumerable<IPostLikeIncluder> Create(ICollection<PostsIncludeDescriptor>? descriptors)
    {
        if (descriptors == null)
        {
            return [];
        }

        var includers = _includers.Where(s => descriptors.Any(p =>
                                                        p.IncludeType == s.IncludeType &&
                                                        p.DestinationType == s.DestinationType));

        if (includers.IsEmpty())
        {
            throw new PostCommentIncludeDescriptorsNotSupportedException(descriptors);
        }

        return includers;
    }
}
