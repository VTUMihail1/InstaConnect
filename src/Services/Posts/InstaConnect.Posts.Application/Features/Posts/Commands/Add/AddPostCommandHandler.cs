namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

internal class AddPostCommandHandler : ICommandHandler<AddPostCommand, PostCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostFactory _postFactory;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostWriteRepository _postWriteRepository;
    private readonly IUserWriteRepository _userWriteRepository;

    public AddPostCommandHandler(
        IUnitOfWork unitOfWork,
        IPostFactory postFactory,
        IInstaConnectMapper instaConnectMapper,
        IPostWriteRepository postWriteRepository,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _postFactory = postFactory;
        _instaConnectMapper = instaConnectMapper;
        _postWriteRepository = postWriteRepository;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<PostCommandViewModel> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var post = _postFactory.Get(request.CurrentUserId, request.Title, request.Content);
        _postWriteRepository.Add(post);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentViewModel = _instaConnectMapper.Map<PostCommandViewModel>(post);

        return postCommentViewModel;
    }
}
