using InstaConnect.Posts.Application.Features.Posts.Commands.Add;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand, UpdatePostCommandResponse>
{
    private readonly IPostService _postService;
    private readonly IApplicationMapper _applicationMapper;

    public UpdatePostCommandHandler(
        IPostService postService,
        IApplicationMapper applicationMapper)
    {
        _postService = postService;
        _applicationMapper = applicationMapper;
    }

    public async Task<UpdatePostCommandResponse> Handle(
        UpdatePostCommand request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<UpdatePostRequest>(request);
        var post = await _postService.UpdateAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<UpdatePostCommandResponse>(post);

        return response;
    }
}
