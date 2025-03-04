using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers;
internal class PostCommentService : IPostCommentService
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IPostCommentFactory _postCommentFactory;
    private readonly IPostCommentReadRepository _postCommentReadRepository;
    private readonly IPostCommentWriteRepository _postCommentWriteRepository;

    public PostCommentService(
        IDateTimeProvider dateTimeProvider,
        IPostCommentFactory postCommentFactory,
        IPostCommentReadRepository postCommentReadRepository,
        IPostCommentWriteRepository postCommentWriteRepository)
    {
        _dateTimeProvider = dateTimeProvider;
        _postCommentFactory = postCommentFactory;
        _postCommentReadRepository = postCommentReadRepository;
        _postCommentWriteRepository = postCommentWriteRepository;
    }
    public async Task<PaginationList<PostComment>> GetAllAsync(
        Post post,
        PostCommentCollectionReadQuery query,
        CancellationToken cancellationToken)
    {
        var postComments = await _postCommentReadRepository.GetAllAsync(query, cancellationToken);

        return postComments;
    }

    public async Task<PostComment> GetByIdAsync(Post post, string id, CancellationToken cancellationToken)
    {
        var postComment = await _postCommentReadRepository.GetByIdAsync(id, cancellationToken);

        if (postComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        return postComment;
    }

    public PostComment Add(Post post, string content, string userId)
    {
        var postComment = _postCommentFactory.Get(post.Id, userId, content);
        _postCommentWriteRepository.Add(postComment);

        return postComment;
    }

    public async Task<PostComment> UpdateAsync(Post post, string id, string userId, string content, CancellationToken cancellationToken)
    {
        var postComment = await _postCommentReadRepository.GetByIdAsync(id, cancellationToken);

        if (postComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        if (userId != postComment.UserId)
        {
            throw new UserForbiddenException();
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        postComment.Update(content, utcNow);
        _postCommentWriteRepository.Update(postComment);

        return postComment;
    }

    public async Task DeleteAsync(Post post, string id, string userId, CancellationToken cancellationToken)
    {
        var postComment = await _postCommentReadRepository.GetByIdAsync(id, cancellationToken);

        if (postComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        if (userId != postComment.UserId)
        {
            throw new UserForbiddenException();
        }

        _postCommentWriteRepository.Delete(postComment);
    }
}
