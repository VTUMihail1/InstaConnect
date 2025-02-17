namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;

internal class AddPostLikeCommandHandler : ICommandHandler<AddPostLikeCommand, PostLikeCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IPostWriteRepository _postWriteRepository;
    private readonly IPostLikeWriteRepository _postLikeWriteRepository;

    public AddPostLikeCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IPostWriteRepository postWriteRepository,
        IPostLikeWriteRepository postLikeWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _postWriteRepository = postWriteRepository;
        _postLikeWriteRepository = postLikeWriteRepository;
    }

    public async Task<PostLikeCommandViewModel> Handle(
        AddPostLikeCommand request,
        CancellationToken cancellationToken)
    {
        var existingPost = await _postWriteRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var existingUser = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var existingPostLike = await _postLikeWriteRepository.GetByUserIdAndPostIdAsync(request.CurrentUserId, request.PostId, cancellationToken);

        if (existingPostLike != null)
        {
            throw new PostLikeAlreadyExistsException();
        }

        var postLike = _instaConnectMapper.Map<PostLike>(request);
        _postLikeWriteRepository.Add(postLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postLikeCommandViewModel = _instaConnectMapper.Map<PostLikeCommandViewModel>(postLike);

        return postLikeCommandViewModel;
    }
}
