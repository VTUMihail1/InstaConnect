using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class PostCommentIncluderFactory : IPostCommentIncluderFactory
{
    private readonly IEnumerable<IPostCommentIncluder> _includers;

    public PostCommentIncluderFactory(IEnumerable<IPostCommentIncluder> includers)
    {
        _includers = includers;
    }

    public IEnumerable<IPostCommentIncluder> Create(ICollection<PostsIncludeDescriptor>? descriptors)
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
