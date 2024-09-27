using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostComments.Commands.DeletePostComment;

internal class DeletePostCommentCommandHandler : ICommandHandler<DeletePostCommentCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostCommentWriteRepository _postCommentWriteRepository;

    public DeletePostCommentCommandHandler(
        IUnitOfWork unitOfWork,
        IPostCommentWriteRepository postCommentWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _postCommentWriteRepository = postCommentWriteRepository;
    }

    public async Task Handle(
        DeletePostCommentCommand request,
        CancellationToken cancellationToken)
    {
        var existingPostComment = await _postCommentWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        if (request.CurrentUserId != existingPostComment.UserId)
        {
            throw new UserForbiddenException();
        }

        _postCommentWriteRepository.Delete(existingPostComment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
