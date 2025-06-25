namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;

internal class AddPostCommentLikeCommandHandler : ICommandHandler<AddPostCommentLikeCommand, PostCommentLikeCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserRepository _userWriteRepository;
    private readonly IPostWriteRepository _postWriteRepository;
    private readonly IPostCommentLikeService _postCommentLikeService;

    public AddPostCommentLikeCommandHandler(
        IUnitOfWork unitOfWork,
        IApplicationMapper applicationMapper,
        IUserRepository userWriteRepository,
        IPostWriteRepository postWriteRepository,
        IPostCommentLikeService postCommentLikeService)
    {
        _unitOfWork = unitOfWork;
        _applicationMapper = applicationMapper;
        _userWriteRepository = userWriteRepository;
        _postWriteRepository = postWriteRepository;
        _postCommentLikeService = postCommentLikeService;
    }

    public async Task<PostCommentLikeCommandViewModel> Handle(
        AddPostCommentLikeCommand request,
        CancellationToken cancellationToken)
    {
        var existingPost= await _postWriteRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var existingUser = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var postCommentLike = await _postCommentLikeService.AddAsync(existingPost, request.PostCommentId, request.CurrentUserId, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentLikeCommandViewModel = _applicationMapper.Map<PostCommentLikeCommandViewModel>(postCommentLike);

        return postCommentLikeCommandViewModel;
    }
}
