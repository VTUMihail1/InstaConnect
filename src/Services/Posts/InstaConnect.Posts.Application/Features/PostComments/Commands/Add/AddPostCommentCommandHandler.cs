namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Add;

internal class AddPostCommentCommandHandler : ICommandHandler<AddPostCommentCommandRequest, AddPostCommentCommandResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentService _postCommentService;

    public AddPostCommentCommandHandler(
        IApplicationMapper applicationMapper,
        IPostCommentService postCommentService)
    {
        _applicationMapper = applicationMapper;
        _postCommentService = postCommentService;
    }

    public async Task<AddPostCommentCommandResponse> Handle(AddPostCommentCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddPostCommentCommand>(request);
        var postComment = await _postCommentService.AddAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<AddPostCommentCommandResponse>(postComment);

        return response;
    }
}
