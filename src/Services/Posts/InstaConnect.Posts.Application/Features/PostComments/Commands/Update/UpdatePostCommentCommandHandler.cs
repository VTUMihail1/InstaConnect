namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

internal class UpdatePostCommentCommandHandler : ICommandHandler<UpdatePostCommentCommand, PostCommentCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentService _postCommentService;
    private readonly IPostWriteRepository _postWriteRepository;

    public UpdatePostCommentCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IPostCommentService postCommentService,
        IPostWriteRepository postWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _postCommentService = postCommentService;
        _postWriteRepository = postWriteRepository;
    }

    public async Task<PostCommentCommandViewModel> Handle(
        UpdatePostCommentCommand request,
        CancellationToken cancellationToken)
    {
        var existingPost = await _postWriteRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var postComment = await _postCommentService.UpdateAsync(existingPost, request.Id, request.CurrentUserId, request.Content, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentCommand = _instaConnectMapper.Map<PostCommentCommandViewModel>(postComment);

        return postCommentCommand;
    }
}
