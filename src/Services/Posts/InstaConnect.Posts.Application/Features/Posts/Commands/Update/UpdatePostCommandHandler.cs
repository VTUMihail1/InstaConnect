using InstaConnect.Posts.Application.Features.Posts.Commands.Add;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand, UpdatePostCommandResponse>
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

    public async Task<UpdatePostCommandResponse> Handle(
        UpdatePostCommand request,
        CancellationToken cancellationToken)
    {
        var post = await _postWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException();
        }

        if (request.CurrentUserId != post.UserId)
        {
            throw new UserForbiddenException();
        }

        _postService.Update(post, request.Title, request.Content);
        _postWriteRepository.Update(post);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = _instaConnectMapper.Map<UpdatePostCommandResponse>(post);

        return response;
    }
}
