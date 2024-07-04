using AutoMapper;
using InstaConnect.Follows.Write.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Follows;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Follow;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Follows.Write.Business.Commands.Follows.DeleteFollow;

public class DeleteFollowCommandHandler : ICommandHandler<DeleteFollowCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IFollowRepository _followRepository;

    public DeleteFollowCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPublishEndpoint publishEndpoint,
        IFollowRepository followRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
        _followRepository = followRepository;
    }

    public async Task Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
    {
        var existingFollow = await _followRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingFollow == null)
        {
            throw new FollowNotFoundException();
        }

        if (request.CurrentUserId != existingFollow.FollowerId)
        {
            throw new AccountForbiddenException();
        }

        _followRepository.Delete(existingFollow);

        var followDeletedEvent = _mapper.Map<FollowDeletedEvent>(existingFollow);
        await _publishEndpoint.Publish(followDeletedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
