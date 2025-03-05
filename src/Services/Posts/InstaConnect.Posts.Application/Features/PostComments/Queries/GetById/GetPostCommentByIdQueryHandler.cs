using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

internal class GetPostCommentByIdQueryHandler : IQueryHandler<GetPostCommentByIdQuery, PostCommentQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentService _postCommentService;
    private readonly IPostReadRepository _postReadRepository;

    public GetPostCommentByIdQueryHandler(
        IInstaConnectMapper mapper,
        IPostCommentService postCommentService,
        IPostReadRepository postReadRepository)
    {
        _instaConnectMapper = mapper;
        _postCommentService = postCommentService;
        _postReadRepository = postReadRepository;
    }

    public async Task<PostCommentQueryViewModel> Handle(GetPostCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var existingPost = await _postReadRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var postComment = await _postCommentService.GetByIdAsync(existingPost, request.Id, cancellationToken);

        var response = _instaConnectMapper.Map<PostCommentQueryViewModel>(postComment);

        return response;
    }
}
