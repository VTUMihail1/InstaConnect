using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Events.Abstractions;

namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;
internal class FollowService : IFollowService
{
    private readonly IFollowFactory _followFactory;
    private readonly IEventPublisher _eventPublisher;
    private readonly IUserRepository _userRepository;
    private readonly IFollowRepository _followRepository;
    private readonly IApplicationMapper _applicationMapper;

    public FollowService(
        IFollowFactory followFactory,
        IEventPublisher eventPublisher,
        IUserRepository userRepository,
        IFollowRepository followRepository,
        IApplicationMapper applicationMapper)
    {
        _followFactory = followFactory;
        _eventPublisher = eventPublisher;
        _userRepository = userRepository;
        _followRepository = followRepository;
        _applicationMapper = applicationMapper;
    }

    public async Task<FollowCollection> GetAllByFollowerAsync(GetAllFollowsByFollowerQuery query, CancellationToken cancellationToken)
    {
        var existingFollower = await _userRepository.GetByIdAsync(query.Filter.FollowerId, cancellationToken);

        if (existingFollower.IsNull())
        {
            throw new UserNotFoundException(query.Filter.FollowerId);
        }

        var existingFollowCollection = await _followRepository.GetAllByFollowerAsync(
            query.Filter,
            query.Sorting,
            query.Pagination,
            query.Include,
            cancellationToken);

        return existingFollowCollection;
    }

    public async Task<FollowCollection> GetAllByFollowingAsync(GetAllFollowsByFollowingQuery query, CancellationToken cancellationToken)
    {
        var existingFollowing = await _userRepository.GetByIdAsync(query.Filter.FollowingId, cancellationToken);

        if (existingFollowing.IsNull())
        {
            throw new UserNotFoundException(query.Filter.FollowingId);
        }

        var existingFollowCollection = await _followRepository.GetAllByFollowingAsync(
            query.Filter,
            query.Sorting,
            query.Pagination,
            query.Include,
            cancellationToken);

        return existingFollowCollection;
    }

    public async Task<Follow> GetByIdAsync(GetFollowByIdQuery query, CancellationToken cancellationToken)
    {
        var existingFollow = await _followRepository.GetByIdAsync(
            query.FollowerId,
            query.FollowingId,
            query.Include,
            cancellationToken);

        if (existingFollow.IsNull())
        {
            throw new FollowNotFoundException(query.FollowerId, query.FollowingId);
        }

        return existingFollow!;
    }

    public async Task<Follow> AddAsync(AddFollowCommand command, CancellationToken cancellationToken)
    {
        var existingFollower = await _userRepository.GetByIdAsync(command.FollowerId, cancellationToken);

        if (existingFollower.IsNull())
        {
            throw new UserNotFoundException(command.FollowerId);
        }

        var existingFollowing = await _userRepository.GetByIdAsync(command.FollowingId, cancellationToken);

        if (existingFollowing.IsNull())
        {
            throw new UserNotFoundException(command.FollowingId);
        }

        var existingFollow = await _followRepository.GetByIdAsync(command.FollowerId, command.FollowingId, cancellationToken);

        if (existingFollow.IsNotNull())
        {
            throw new FollowAlreadyExistsException(command.FollowerId, command.FollowingId);
        }

        var follow = _followFactory.Create(command.FollowerId, command.FollowingId);
        await _followRepository.AddAsync(follow, cancellationToken);

        var eventRequest = _applicationMapper.Map<FollowAddedEventRequest>(follow);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return follow;
    }

    public async Task DeleteAsync(DeleteFollowCommand command, CancellationToken cancellationToken)
    {
        var existingFollow = await _followRepository.GetByIdAsync(command.FollowerId, command.FollowingId, cancellationToken);

        if (existingFollow.IsNull())
        {
            throw new FollowNotFoundException(command.FollowerId, command.FollowingId);
        }

        await _followRepository.DeleteAsync(existingFollow!, cancellationToken);

        var eventRequest = _applicationMapper.Map<FollowDeletedEventRequest>(existingFollow!);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}
