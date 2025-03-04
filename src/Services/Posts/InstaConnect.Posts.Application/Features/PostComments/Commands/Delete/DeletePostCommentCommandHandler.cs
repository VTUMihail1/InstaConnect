namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;

internal class DeletePostCommentCommandHandler : ICommandHandler<DeletePostCommentCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostCommentService _postCommentService;
    private readonly IPostWriteRepository _postWriteRepository;

    public DeletePostCommentCommandHandler(
        IUnitOfWork unitOfWork,
        IPostCommentService postCommentService,
        IPostWriteRepository postWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _postCommentService = postCommentService;
        _postWriteRepository = postWriteRepository;
    }

    public async Task Handle(
        DeletePostCommentCommand request,
        CancellationToken cancellationToken)
    {
        var existingPost = await _postWriteRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        await _postCommentService.DeleteAsync(existingPost, request.Id, request.CurrentUserId, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
