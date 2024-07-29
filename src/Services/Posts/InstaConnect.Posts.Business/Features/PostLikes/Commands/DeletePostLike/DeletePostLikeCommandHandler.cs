using InstaConnect.Posts.Data.Features.PostLikes.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostLikes.Commands.DeletePostLike;

internal class DeletePostLikeCommandHandler : ICommandHandler<DeletePostLikeCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostLikeWriteRepository _postLikeWriteRepository;

    public DeletePostLikeCommandHandler(
        IUnitOfWork unitOfWork,
        IPostLikeWriteRepository postLikeWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _postLikeWriteRepository = postLikeWriteRepository;
    }

    public async Task Handle(DeletePostLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPostLike = await _postLikeWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        if (request.CurrentUserId != existingPostLike.UserId)
        {
            throw new AccountForbiddenException();
        }

        _postLikeWriteRepository.Delete(existingPostLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
