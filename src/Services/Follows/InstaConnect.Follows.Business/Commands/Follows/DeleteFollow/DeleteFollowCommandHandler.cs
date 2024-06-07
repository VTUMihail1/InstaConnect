using AutoMapper;
using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Follow;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Follows.Business.Commands.Follows.DeleteFollow;

public class DeleteFollowCommandHandler : ICommandHandler<DeleteFollowCommand>
{
    private readonly IFollowRepository _followRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public DeleteFollowCommandHandler(
        IFollowRepository followRepository,
        ICurrentUserContext currentUserContext)
    {
        _followRepository = followRepository;
        _currentUserContext = currentUserContext;
    }

    public async Task Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
    {
        var existingFollow = await _followRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingFollow == null)
        {
            throw new FollowNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();

        if (currentUserDetails.Id != existingFollow.FollowerId)
        {
            throw new AccountForbiddenException();
        }

        await _followRepository.DeleteAsync(existingFollow, cancellationToken);
    }
}
