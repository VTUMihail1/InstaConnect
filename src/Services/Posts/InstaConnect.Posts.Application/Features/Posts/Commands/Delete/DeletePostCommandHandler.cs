using InstaConnect.Posts.Application.Features.Posts.Commands.Add;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Delete;

internal class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostService _postService;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public DeletePostCommandHandler(
        IUnitOfWork unitOfWork,
        IPostService postService,
        IInstaConnectMapper instaConnectMapper)
    {
        _unitOfWork = unitOfWork;
        _postService = postService;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task Handle(
        DeletePostCommand request, 
        CancellationToken cancellationToken)
    {
        var serviceRequest = _instaConnectMapper.Map<DeletePostRequest>(request);
        await _postService.DeleteAsync(serviceRequest, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
