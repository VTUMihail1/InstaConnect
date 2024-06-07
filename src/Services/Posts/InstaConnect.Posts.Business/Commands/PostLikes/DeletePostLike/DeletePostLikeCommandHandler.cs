using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostLikes.DeletePostLike;

internal class DeletePostLikeCommandHandler : ICommandHandler<DeletePostLikeCommand>
{
    private readonly IPostLikeRepository _postLikeRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public DeletePostLikeCommandHandler(
        IPostLikeRepository postLikeRepository,
        ICurrentUserContext currentUserContext)
    {
        _postLikeRepository = postLikeRepository;
        _currentUserContext = currentUserContext;
    }

    public async Task Handle(DeletePostLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPostLike = await _postLikeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();

        if (currentUserDetails.Id != existingPostLike.UserId)
        {
            throw new AccountForbiddenException();
        }

        await _postLikeRepository.DeleteAsync(existingPostLike, cancellationToken);
    }
}
