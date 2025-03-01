namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Add;

internal class AddPostCommentCommandHandler : ICommandHandler<AddPostCommentCommand, PostCommentCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentFactory _postCommentFactory;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IPostWriteRepository _postWriteRepository;
    private readonly IPostCommentWriteRepository _postCommentWriteRepository;

    public AddPostCommentCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IPostCommentFactory postCommentFactory,
        IUserWriteRepository userWriteRepository,
        IPostWriteRepository postWriteRepository,
        IPostCommentWriteRepository postCommentWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _postCommentFactory = postCommentFactory;
        _userWriteRepository = userWriteRepository;
        _postWriteRepository = postWriteRepository;
        _postCommentWriteRepository = postCommentWriteRepository;
    }

    public async Task<PostCommentCommandViewModel> Handle(
        AddPostCommentCommand request,
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

        var postComment = _postCommentFactory.Get(request.PostId, request.CurrentUserId, request.Content);
        _postCommentWriteRepository.Add(postComment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentCommandViewModel = _instaConnectMapper.Map<PostCommentCommandViewModel>(postComment);

        return postCommentCommandViewModel;
    }
}
