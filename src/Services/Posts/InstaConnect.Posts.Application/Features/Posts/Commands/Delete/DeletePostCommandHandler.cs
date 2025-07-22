using InstaConnect.Posts.Application.Features.Posts.Commands.Add;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Delete;

internal class DeletePostCommandHandler : ICommandHandler<DeletePostCommandRequest>
{
    private readonly IPostService _postService;
    private readonly IApplicationMapper _applicationMapper;

    public DeletePostCommandHandler(
        IPostService postService,
        IApplicationMapper applicationMapper)
    {
        _postService = postService;
        _applicationMapper = applicationMapper;
    }

    public async Task Handle(
        DeletePostCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<DeletePostCommand>(request);
        await _postService.DeleteAsync(serviceRequest, cancellationToken);
    }
}
