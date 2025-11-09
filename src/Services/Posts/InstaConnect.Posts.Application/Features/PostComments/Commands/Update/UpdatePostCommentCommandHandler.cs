namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

public class UpdatePostCommentCommandHandler : ICommandHandler<UpdatePostCommentCommandRequest, UpdatePostCommentCommandResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentService _postCommentService;

    public UpdatePostCommentCommandHandler(
        IApplicationMapper applicationMapper,
        IPostCommentService postCommentService)
    {
        _applicationMapper = applicationMapper;
        _postCommentService = postCommentService;
    }

    public async Task<UpdatePostCommentCommandResponse> Handle(
        UpdatePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<UpdatePostCommentCommand>(request);
        var postComment = await _postCommentService.UpdateAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<UpdatePostCommentCommandResponse>(postComment);

        return response;
    }
}
