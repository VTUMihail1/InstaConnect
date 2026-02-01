using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includers;
internal class PostIncluderFactory : IPostIncluderFactory
{
    private readonly IEnumerable<IPostIncluder> _includers;

    public PostIncluderFactory(IEnumerable<IPostIncluder> includers)
    {
        _includers = includers;
    }

    public IEnumerable<IPostIncluder> Create(ICollection<PostsIncludeDescriptor>? descriptors)
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
