using AutoMapper;
using InstaConnect.Follows.Data.Write.Abstractions;
using InstaConnect.Follows.Data.Write.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Follows;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Follows.Business.Commands.Follows.AddFollow;

internal class AddFollowCommandHandler : ICommandHandler<AddFollowCommand>
{
    private const string USER_ALREADY_FOLLOWED = "This user has already been followed";

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IFollowRepository _followRepository;
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IRequestClient<GetUserByIdRequest> _getUserByIdRequestClient;

    public AddFollowCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPublishEndpoint publishEndpoint,
        IFollowRepository followRepository,
        ICurrentUserContext currentUserContext,
        IRequestClient<GetUserByIdRequest> getUserByIdRequestClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
        _followRepository = followRepository;
        _currentUserContext = currentUserContext;
        _getUserByIdRequestClient = getUserByIdRequestClient;
    }

    public async Task Handle(AddFollowCommand request, CancellationToken cancellationToken)
    {
        var getUserByIdRequest = _mapper.Map<GetUserByIdRequest>(request);
        var getUserByIdResponse = await _getUserByIdRequestClient.GetResponse<GetUserByIdResponse>(getUserByIdRequest, cancellationToken);

        if (getUserByIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();

        var existingFollow = await _followRepository.GetByFollowerIdAndFollowingIdAsync(currentUserDetails.Id!, request.FollowingId, cancellationToken);

        if (existingFollow != null)
        {
            throw new BadRequestException(USER_ALREADY_FOLLOWED);
        }

        var follow = _mapper.Map<Follow>(request);
        _mapper.Map(currentUserDetails, follow);
        _followRepository.Add(follow);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var followCreatedEvent = _mapper.Map<FollowCreatedEvent>(follow);
        await _publishEndpoint.Publish(followCreatedEvent, cancellationToken);
    }
}
