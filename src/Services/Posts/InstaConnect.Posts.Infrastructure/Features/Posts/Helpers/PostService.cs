using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers;
internal class PostService : IPostService
{
    private readonly IPostLikeFactory _postLikeFactory;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IPostCommentService _postCommentService;
    private readonly IPostCommentFactory _postCommentFactory;
    private readonly IPostLikeWriteRepository _postLikeWriteRepository;
    private readonly IPostCommentWriteRepository _postCommentWriteRepository;

    public PostService(
        IPostLikeFactory postLikeFactory,
        IDateTimeProvider dateTimeProvider,
        IPostCommentService postCommentService,
        IPostCommentFactory postCommentFactory,
        IPostLikeWriteRepository postLikeWriteRepository,
        IPostCommentWriteRepository postCommentWriteRepository)
    {
        _postLikeFactory = postLikeFactory;
        _dateTimeProvider = dateTimeProvider;
        _postCommentService = postCommentService;
        _postCommentFactory = postCommentFactory;
        _postLikeWriteRepository = postLikeWriteRepository;
        _postCommentWriteRepository = postCommentWriteRepository;
    }

    public void AddComment(Post post, string content, string userId)
    {
        var comment = _postCommentFactory.Get(post.Id, userId, content);
        _postCommentWriteRepository.Add(comment);
    }
    public void AddCommentLike(Post post, string commentId, string userId)
    {
        var comment = _postCommentWriteRepository.GetByIdAsync(commentId)
        _postCommentService.AddLike()
    }
    public void AddLike(Post post, string userId) => throw new NotImplementedException();
    public void GetAllCommentLikes(Post post, string commentId, PostLikeCollectionReadQuery query) => throw new NotImplementedException();
    public void GetAllComments(Post post, PostCommentCollectionReadQuery query) => throw new NotImplementedException();
    public void GetAllLikes(Post post, PostLikeCollectionReadQuery query) => throw new NotImplementedException();
    public void GetCommentById(Post post, string commentId) => throw new NotImplementedException();
    public void GetCommentLikeById(Post post, string commentId, string commentLikeId) => throw new NotImplementedException();
    public void GetLikeById(Post post, string likeId) => throw new NotImplementedException();
    public void RemoveComment(Post post, string commentId) => throw new NotImplementedException();
    public void RemoveCommentLike(Post post, string commentLikeId) => throw new NotImplementedException();
    public void RemoveLike(Post post, string likeId) => throw new NotImplementedException();

    public void Update(Post post, string title, string content)
    {
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        post.Update(title, content, utcNow);
    }
}
