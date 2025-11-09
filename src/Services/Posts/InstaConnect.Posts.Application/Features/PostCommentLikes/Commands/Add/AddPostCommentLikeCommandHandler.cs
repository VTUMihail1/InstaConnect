namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;

internal class AddPostCommentLikeCommandHandler : ICommandHandler<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommandResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentLikeService _postCommentLikeService;

    public AddPostCommentLikeCommandHandler(
        IApplicationMapper applicationMapper,
        IPostCommentLikeService postCommentLikeService)
    {
        _applicationMapper = applicationMapper;
        _postCommentLikeService = postCommentLikeService;
    }

    public async Task<AddPostCommentLikeCommandResponse> Handle(AddPostCommentLikeCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddPostCommentLikeCommand>(request);
        var postCommentLike = await _postCommentLikeService.AddAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<AddPostCommentLikeCommandResponse>(postCommentLike);

        return response;
    }
}
