using InstaConnect.Posts.Application.Features.Posts.Commands.Add;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Delete;

internal class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
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
        DeletePostCommand request, 
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<DeletePostRequest>(request);
        await _postService.DeleteAsync(serviceRequest, cancellationToken);
    }
}
