using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers;
internal class PostLikeService : IPostLikeService
{
    private readonly IPostLikeFactory _postLikeFactory;
    private readonly IPostLikeReadRepository _postLikeReadRepository;
    private readonly IPostLikeWriteRepository _postLikeWriteRepository;

    public PostLikeService(
        IPostLikeFactory postLikeFactory,
        IPostLikeReadRepository postLikeReadRepository,
        IPostLikeWriteRepository postLikeWriteRepository)
    {
        _postLikeFactory = postLikeFactory;
        _postLikeReadRepository = postLikeReadRepository;
        _postLikeWriteRepository = postLikeWriteRepository;
    }
    public async Task<PaginationList<PostLike>> GetAllAsync(
        Post post,
        PostLikeCollectionReadQuery query,
        CancellationToken cancellationToken)
    {
        var postLikes = await _postLikeReadRepository.GetAllAsync(query, cancellationToken);

        return postLikes;
    }

    public async Task<PostLike> GetByIdAsync(Post post, string id, CancellationToken cancellationToken)
    {
        var postLike = await _postLikeReadRepository.GetByIdAsync(id, cancellationToken);

        if (postLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        return postLike;
    }

    public void Add(Post post, string userId)
    {
        var postLike = _postLikeFactory.Get(post.Id, userId);
        _postLikeWriteRepository.Add(postLike);
    }

    public async Task DeleteAsync(Post post, string id, CancellationToken cancellationToken)
    {
        var postLike = await _postLikeReadRepository.GetByIdAsync(id, cancellationToken);

        if (postLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        _postLikeWriteRepository.Delete(postLike);
    }
}
