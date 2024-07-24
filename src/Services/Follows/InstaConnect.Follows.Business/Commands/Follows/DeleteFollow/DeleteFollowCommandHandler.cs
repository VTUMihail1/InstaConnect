﻿using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Follow;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Follows.Write.Business.Commands.Follows.DeleteFollow;

internal class DeleteFollowCommandHandler : ICommandHandler<DeleteFollowCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFollowWriteRepository _followWriteRepository;

    public DeleteFollowCommandHandler(
        IUnitOfWork unitOfWork,
        IFollowWriteRepository followWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _followWriteRepository = followWriteRepository;
    }

    public async Task Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
    {
        var existingFollow = await _followWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingFollow == null)
        {
            throw new FollowNotFoundException();
        }

        if (request.CurrentUserId != existingFollow.FollowerId)
        {
            throw new AccountForbiddenException();
        }

        _followWriteRepository.Delete(existingFollow);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
