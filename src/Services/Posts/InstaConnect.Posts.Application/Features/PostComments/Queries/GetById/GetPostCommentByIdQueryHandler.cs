using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

internal class GetPostCommentByIdQueryHandler : IQueryHandler<GetPostCommentByIdQuery, PostCommentQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentService _postCommentService;
    private readonly IPostReadRepository _postReadRepository;

    public GetPostCommentByIdQueryHandler(
        IApplicationMapper mapper,
        IPostCommentService postCommentService,
        IPostReadRepository postReadRepository)
    {
        _applicationMapper = mapper;
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

        var response = _applicationMapper.Map<PostCommentQueryViewModel>(postComment);

        return response;
    }
}
