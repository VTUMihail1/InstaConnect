namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand, PostCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostService _postService;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostWriteRepository _postWriteRepository;

    public UpdatePostCommandHandler(
        IUnitOfWork unitOfWork,
        IPostService postService,
        IInstaConnectMapper instaConnectMapper,
        IPostWriteRepository postWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _postService = postService;
        _instaConnectMapper = instaConnectMapper;
        _postWriteRepository = postWriteRepository;
    }

    public async Task<PostCommandViewModel> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        if (request.CurrentUserId != existingPost.UserId)
        {
            throw new UserForbiddenException();
        }

        _postService.Update(existingPost, request.Title, request.Content);
        _postWriteRepository.Update(existingPost);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentViewModel = _instaConnectMapper.Map<PostCommandViewModel>(existingPost);

        return postCommentViewModel;
    }
}
