namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

internal class AddPostCommandHandler : ICommandHandler<AddPostCommand, AddPostCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostService _postService;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public AddPostCommandHandler(
        IUnitOfWork unitOfWork,
        IPostService postService,
        IInstaConnectMapper instaConnectMapper)
    {
        _unitOfWork = unitOfWork;
        _postService = postService;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task<AddPostCommandResponse> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var serviceRequest = _instaConnectMapper.Map<AddPostRequest>(request);
        var post = _postService.AddAsync(serviceRequest, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = _instaConnectMapper.Map<AddPostCommandResponse>(post);

        return response;
    }
}
