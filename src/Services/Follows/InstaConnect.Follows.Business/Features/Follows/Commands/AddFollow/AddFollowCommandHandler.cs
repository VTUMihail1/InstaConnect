using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Data.Features.Follows.Abstractions;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Follows.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;

internal class AddFollowCommandHandler : ICommandHandler<AddFollowCommand, FollowCommandViewModel>
{
    private const string USER_ALREADY_FOLLOWED = "This user has already been followed";

    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IFollowWriteRepository _followWriteRepository;

    public AddFollowCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IFollowWriteRepository followWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _followWriteRepository = followWriteRepository;
    }

    public async Task<FollowCommandViewModel> Handle(
        AddFollowCommand request,
        CancellationToken cancellationToken)
    {
        var existingFollower = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingFollower == null)
        {
            throw new UserNotFoundException();
        }

        var existingFollowing = await _userWriteRepository.GetByIdAsync(request.FollowingId, cancellationToken);

        if (existingFollowing == null)
        {
            throw new UserNotFoundException();
        }

        var existingFollow = await _followWriteRepository.GetByFollowerIdAndFollowingIdAsync(
            request.CurrentUserId,
            request.FollowingId,
            cancellationToken);

        if (existingFollow != null)
        {
            throw new BadRequestException(USER_ALREADY_FOLLOWED);
        }

        var follow = _instaConnectMapper.Map<Follow>(request);
        _followWriteRepository.Add(follow);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var followCommandViewModel = _instaConnectMapper.Map<FollowCommandViewModel>(follow);

        return followCommandViewModel;
    }
}
