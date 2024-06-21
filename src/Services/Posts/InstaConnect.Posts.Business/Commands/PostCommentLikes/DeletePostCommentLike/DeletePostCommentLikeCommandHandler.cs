using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;

internal class DeletePostCommentLikeCommandHandler : ICommandHandler<DeletePostCommentLikeCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;

    public DeletePostCommentLikeCommandHandler(
        IUnitOfWork unitOfWork,
        ICurrentUserContext currentUserContext,
        IPostCommentLikeRepository postCommentLikeRepository)
    {
        _unitOfWork = unitOfWork;
        _currentUserContext = currentUserContext;
        _postCommentLikeRepository = postCommentLikeRepository;
    }

    public async Task Handle(DeletePostCommentLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPostCommentLike = await _postCommentLikeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostCommentLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();

        if (currentUserDetails.Id != existingPostCommentLike.UserId)
        {
            throw new AccountForbiddenException();
        }

        _postCommentLikeRepository.Delete(existingPostCommentLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
