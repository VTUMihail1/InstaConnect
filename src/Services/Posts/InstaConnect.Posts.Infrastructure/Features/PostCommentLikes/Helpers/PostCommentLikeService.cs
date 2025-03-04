using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers;
internal class PostCommentLikeService : IPostCommentLikeService
{
    private readonly IPostCommentLikeFactory _postCommentLikeFactory;
    private readonly IPostCommentReadRepository _postCommentReadRepository;
    private readonly IPostCommentWriteRepository _postCommentWriteRepository;
    private readonly IPostCommentLikeReadRepository _postCommentLikeReadRepository;
    private readonly IPostCommentLikeWriteRepository _postCommentLikeWriteRepository;

    public PostCommentLikeService(
        IPostCommentLikeFactory postCommentLikeFactory,
        IPostCommentReadRepository postCommentReadRepository,
        IPostCommentWriteRepository postCommentWriteRepository,
        IPostCommentLikeReadRepository postCommentLikeReadRepository,
        IPostCommentLikeWriteRepository postCommentLikeWriteRepository)
    {
        _postCommentLikeFactory = postCommentLikeFactory;
        _postCommentReadRepository = postCommentReadRepository;
        _postCommentWriteRepository = postCommentWriteRepository;
        _postCommentLikeReadRepository = postCommentLikeReadRepository;
        _postCommentLikeWriteRepository = postCommentLikeWriteRepository;
    }
    public async Task<PaginationList<PostCommentLike>> GetAllAsync(
        Post post,
        string postCommentId,
        PostCommentLikeCollectionReadQuery query,
        CancellationToken cancellationToken)
    {
        var postComment = await _postCommentReadRepository.GetByIdAsync(postCommentId, cancellationToken);

        if (postComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var postCommentLikes = await _postCommentLikeReadRepository.GetAllAsync(query, cancellationToken);

        return postCommentLikes;
    }

    public async Task<PostCommentLike> GetByIdAsync(Post post, string postCommentId, string id, CancellationToken cancellationToken)
    {
        var postComment = await _postCommentReadRepository.GetByIdAsync(postCommentId, cancellationToken);

        if (postComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var postCommentLike = await _postCommentLikeReadRepository.GetByIdAsync(id, cancellationToken);

        if (postCommentLike == null)
        {
            throw new PostCommentLikeNotFoundException();
        }

        return postCommentLike;
    }

    public async Task AddAsync(Post post, string postCommentId, string userId, CancellationToken cancellationToken)
    {
        var postComment = await _postCommentWriteRepository.GetByIdAsync(postCommentId, cancellationToken);

        if (postComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var postCommentLike = _postCommentLikeFactory.Get(postCommentId, userId);
        _postCommentLikeWriteRepository.Add(postCommentLike);
    }

    public async Task DeleteAsync(Post post, string postCommentId, string id, CancellationToken cancellationToken)
    {
        var postComment = await _postCommentWriteRepository.GetByIdAsync(postCommentId, cancellationToken);

        if (postComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var postCommentLike = await _postCommentLikeReadRepository.GetByIdAsync(id, cancellationToken);

        if (postCommentLike == null)
        {
            throw new PostCommentLikeNotFoundException();
        }

        _postCommentLikeWriteRepository.Delete(postCommentLike);
    }
}
