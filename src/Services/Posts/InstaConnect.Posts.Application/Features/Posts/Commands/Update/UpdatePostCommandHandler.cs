using InstaConnect.Posts.Application.Features.Posts.Commands.Add;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand, UpdatePostCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostService _postService;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public UpdatePostCommandHandler(
        IUnitOfWork unitOfWork,
        IPostService postService,
        IInstaConnectMapper instaConnectMapper)
    {
        _unitOfWork = unitOfWork;
        _postService = postService;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task<UpdatePostCommandResponse> Handle(
        UpdatePostCommand request,
        CancellationToken cancellationToken)
    {
        var post = await _postService.UpdateAsync(request.Id, request.CurrentUserId, request.Title, request.Content, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = _instaConnectMapper.Map<UpdatePostCommandResponse>(post);

        return response;
    }
}
