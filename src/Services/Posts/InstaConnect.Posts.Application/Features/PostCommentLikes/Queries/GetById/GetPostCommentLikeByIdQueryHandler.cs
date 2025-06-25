namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

internal class GetPostCommentLikeByIdQueryHandler : IQueryHandler<GetPostCommentLikeByIdQuery, PostCommentLikeQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostReadRepository _postReadRepository;
    private readonly IPostCommentLikeService _postCommentLikeService;

    public GetPostCommentLikeByIdQueryHandler(
        IApplicationMapper applicationMapper,
        IPostReadRepository postReadRepository,
        IPostCommentLikeService postCommentLikeService)
    {
        _applicationMapper = applicationMapper;
        _postReadRepository = postReadRepository;
        _postCommentLikeService = postCommentLikeService;
    }

    public async Task<PostCommentLikeQueryViewModel> Handle(GetPostCommentLikeByIdQuery request, CancellationToken cancellationToken)
    {
        var existingPost = await _postReadRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var postCommentLike = await _postCommentLikeService.GetByIdAsync(existingPost, request.PostCommentId, request.Id, cancellationToken);
        var response = _applicationMapper.Map<PostCommentLikeQueryViewModel>(postCommentLike);

        return response;
    }
}
