namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

internal class UpdatePostCommentCommandHandler : ICommandHandler<UpdatePostCommentCommand, PostCommentCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentService _postCommentService;
    private readonly IPostCommentWriteRepository _postCommentRepository;

    public UpdatePostCommentCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IPostCommentService postCommentService,
        IPostCommentWriteRepository postCommentRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _postCommentService = postCommentService;
        _postCommentRepository = postCommentRepository;
    }

    public async Task<PostCommentCommandViewModel> Handle(
        UpdatePostCommentCommand request,
        CancellationToken cancellationToken)
    {
        var existingPostComment = await _postCommentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        if (request.CurrentUserId != existingPostComment.UserId)
        {
            throw new UserForbiddenException();
        }

        _postCommentService.Update(existingPostComment, request.Content);
        _postCommentRepository.Update(existingPostComment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentCommand = _instaConnectMapper.Map<PostCommentCommandViewModel>(existingPostComment);

        return postCommentCommand;
    }
}
