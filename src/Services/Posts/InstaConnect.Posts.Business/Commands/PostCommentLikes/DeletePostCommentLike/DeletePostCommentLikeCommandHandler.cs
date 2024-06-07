using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;

internal class DeletePostCommentLikeCommandHandler : ICommandHandler<DeletePostCommentLikeCommand>
{
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;

    public DeletePostCommentLikeCommandHandler(
        ICurrentUserContext currentUserContext, 
        IPostCommentLikeRepository postCommentLikeRepository)
    {
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

        await _postCommentLikeRepository.DeleteAsync(existingPostCommentLike, cancellationToken);
    }
}
