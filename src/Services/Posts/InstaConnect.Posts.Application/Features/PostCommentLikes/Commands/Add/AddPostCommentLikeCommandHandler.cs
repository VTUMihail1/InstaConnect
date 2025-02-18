namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;

internal class AddPostCommentLikeCommandHandler : ICommandHandler<AddPostCommentLikeCommand, PostCommentLikeCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IPostCommentWriteRepository _postCommentWriteRepository;
    private readonly IPostCommentLikeWriteRepository _postCommentLikeWriteRepository;

    public AddPostCommentLikeCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IPostCommentWriteRepository postCommentRepository,
        IPostCommentLikeWriteRepository postCommentLikeRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _postCommentWriteRepository = postCommentRepository;
        _postCommentLikeWriteRepository = postCommentLikeRepository;
    }

    public async Task<PostCommentLikeCommandViewModel> Handle(
        AddPostCommentLikeCommand request,
        CancellationToken cancellationToken)
    {
        var existingPostComment = await _postCommentWriteRepository.GetByIdAsync(request.PostCommentId, cancellationToken);

        if (existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var existingUser = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var existingPostLike = await _postCommentLikeWriteRepository.GetByUserIdAndPostCommentIdAsync(request.CurrentUserId, request.PostCommentId, cancellationToken);

        if (existingPostLike != null)
        {
            throw new PostCommentLikeAlreadyExistsException();
        }

        var postCommentLike = _instaConnectMapper.Map<PostCommentLike>(request);
        _postCommentLikeWriteRepository.Add(postCommentLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentLikeCommandViewModel = _instaConnectMapper.Map<PostCommentLikeCommandViewModel>(postCommentLike);

        return postCommentLikeCommandViewModel;
    }
}
