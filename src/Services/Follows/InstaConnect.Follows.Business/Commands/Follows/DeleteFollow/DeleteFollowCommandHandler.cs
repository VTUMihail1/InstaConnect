using AutoMapper;
using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Follow;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Follows.Business.Commands.Follows.DeleteFollow;

public class DeleteFollowCommandHandler : ICommandHandler<DeleteFollowCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFollowRepository _followRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public DeleteFollowCommandHandler(
        IUnitOfWork unitOfWork,
        IFollowRepository followRepository,
        ICurrentUserContext currentUserContext)
    {
        _unitOfWork = unitOfWork;
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

        _followRepository.Delete(existingFollow);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
