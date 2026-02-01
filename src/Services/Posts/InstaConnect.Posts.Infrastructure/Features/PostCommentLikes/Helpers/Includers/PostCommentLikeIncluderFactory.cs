using Google.Protobuf.Reflection;

using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;
internal class PostCommentLikeIncluderFactory : IPostCommentLikeIncluderFactory
{
    private readonly IEnumerable<IPostCommentLikeIncluder> _includers;

    public PostCommentLikeIncluderFactory(IEnumerable<IPostCommentLikeIncluder> includeProperties)
    {
        _includers = includeProperties;
    }

    public IEnumerable<IPostCommentLikeIncluder> Create(ICollection<PostsIncludeDescriptor>? descriptors)
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
            throw new PostCommentLikeIncludeDescriptorsNotSupportedException(descriptors);
        }

        return includers;
    }
}
