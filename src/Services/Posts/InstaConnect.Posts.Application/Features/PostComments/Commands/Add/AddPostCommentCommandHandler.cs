namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Add;

internal class AddPostCommentCommandHandler : ICommandHandler<AddPostCommentCommand, PostCommentCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentService _postCommentService;
    private readonly IUserRepository _userWriteRepository;
    private readonly IPostWriteRepository _postWriteRepository;

    public AddPostCommentCommandHandler(
        IUnitOfWork unitOfWork,
        IApplicationMapper applicationMapper,
        IPostCommentService postCommentService,
        IUserRepository userWriteRepository,
        IPostWriteRepository postWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _applicationMapper = applicationMapper;
        _postCommentService = postCommentService;
        _userWriteRepository = userWriteRepository;
        _postWriteRepository = postWriteRepository;
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

        var postComment = _postCommentService.Add(existingPost, request.Content, request.CurrentUserId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentCommandViewModel = _applicationMapper.Map<PostCommentCommandViewModel>(postComment);

        return postCommentCommandViewModel;
    }
}
