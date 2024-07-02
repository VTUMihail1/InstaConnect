using AutoMapper;
using InstaConnect.Follows.Business.Write.Models;
using InstaConnect.Follows.Data.Write.Abstractions;
using InstaConnect.Follows.Data.Write.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Follows;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;

public class AddFollowCommandHandler : ICommandHandler<AddFollowCommand>
{
    private const string USER_ALREADY_FOLLOWED = "This user has already been followed";

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IFollowRepository _followRepository;
    private readonly IRequestClient<GetUserByIdRequest> _getUserByIdRequestClient;

    public AddFollowCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPublishEndpoint publishEndpoint,
        IFollowRepository followRepository,
        IRequestClient<GetUserByIdRequest> getUserByIdRequestClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
        _followRepository = followRepository;
        _getUserByIdRequestClient = getUserByIdRequestClient;
    }

    public async Task Handle(AddFollowCommand request, CancellationToken cancellationToken)
    {
        var followGetUserByIdModel = _mapper.Map<FollowGetUserByIdModel>(request);

        var getUserByFollowerIdResponse = await _getUserByIdRequestClient.GetResponse<GetUserByIdResponse>(
            followGetUserByIdModel.GetUserByFollowerIdRequest,
            cancellationToken);

        if (getUserByFollowerIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var getUserByFollowingIdResponse = await _getUserByIdRequestClient.GetResponse<GetUserByIdResponse>(
            followGetUserByIdModel.GetUserByFollowingIdRequest,
            cancellationToken);

        if (getUserByFollowingIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var existingFollow = await _followRepository.GetByFollowerIdAndFollowingIdAsync(
            request.CurrentUserId,
            request.FollowingId,
            cancellationToken);

        if (existingFollow != null)
        {
            throw new BadRequestException(USER_ALREADY_FOLLOWED);
        }

        var follow = _mapper.Map<Follow>(request);
        _followRepository.Add(follow);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var followCreatedEvent = _mapper.Map<FollowCreatedEvent>(follow);
        await _publishEndpoint.Publish(followCreatedEvent, cancellationToken);
    }
}
