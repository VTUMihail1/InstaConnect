using InstaConnect.Posts.Domain.Features.PostLikes.Abstract;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Exceptions.PostLike;
using InstaConnect.Shared.Common.Exceptions.User;

namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.DeletePostLike;

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
            throw new UserForbiddenException();
        }

        _postLikeWriteRepository.Delete(existingPostLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
