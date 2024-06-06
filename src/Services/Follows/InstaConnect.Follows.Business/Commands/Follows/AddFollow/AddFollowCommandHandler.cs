using AutoMapper;
using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using MassTransit;

namespace InstaConnect.Follows.Business.Commands.Follows.AddFollow;

internal class AddFollowCommandHandler : ICommandHandler<AddFollowCommand>
{
    private const string USER_ALREADY_FOLLOWED = "This user has already been followed";

    private readonly IMapper _mapper;
    private readonly IFollowRepository _followRepository;
    private readonly IRequestClient<GetCurrentUserRequest> _getCurrentUserRequestClient;
    private readonly IRequestClient<ValidateUserByIdRequest> _validateUserByIdRequestClient;

    public AddFollowCommandHandler(
        IMapper mapper, 
        IFollowRepository followRepository, 
        IRequestClient<GetCurrentUserRequest> getCurrentUserRequestClient, 
        IRequestClient<ValidateUserByIdRequest> validateUserByIdRequestClient)
    {
        _mapper = mapper;
        _followRepository = followRepository;
        _getCurrentUserRequestClient = getCurrentUserRequestClient;
        _validateUserByIdRequestClient = validateUserByIdRequestClient;
    }

    public async Task Handle(AddFollowCommand request, CancellationToken cancellationToken)
    {
        var getCurrentUserRequest = _mapper.Map<GetCurrentUserRequest>(request);
        var getCurrentUserResponse = await _getCurrentUserRequestClient.GetResponse<GetCurrentUserResponse>(getCurrentUserRequest, cancellationToken);

        var validateUserByIdRequest = _mapper.Map<ValidateUserByIdRequest>(request);
        await _validateUserByIdRequestClient.GetResponse<ValidateUserByIdResponse>(validateUserByIdRequest, cancellationToken);

        var existingPostLike = _followRepository.GetByFollowerIdAndFollowingIdAsync(getCurrentUserResponse.Message.Id, request.FollowingId, cancellationToken);

        if (existingPostLike == null)
        {
            throw new BadRequestException(USER_ALREADY_FOLLOWED);
        }

        var follow = _mapper.Map<Follow>(request);
        _mapper.Map(getCurrentUserResponse.Message, follow);
        await _followRepository.AddAsync(follow, cancellationToken);
    }
}
