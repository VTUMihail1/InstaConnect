using AutoMapper;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.PostCommentLikes;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;

internal class DeletePostCommentLikeCommandHandler : ICommandHandler<DeletePostCommentLikeCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostCommentLikeWriteRepository _postCommentLikeWriteRepository;

    public DeletePostCommentLikeCommandHandler(
        IUnitOfWork unitOfWork,
        IPostCommentLikeWriteRepository postCommentLikeWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _postCommentLikeWriteRepository = postCommentLikeWriteRepository;
    }

    public async Task Handle(
        DeletePostCommentLikeCommand request,
        CancellationToken cancellationToken)
    {
        var existingPostCommentLike = await _postCommentLikeWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostCommentLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        if (request.CurrentUserId != existingPostCommentLike.UserId)
        {
            throw new AccountForbiddenException();
        }

        _postCommentLikeWriteRepository.Delete(existingPostCommentLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
