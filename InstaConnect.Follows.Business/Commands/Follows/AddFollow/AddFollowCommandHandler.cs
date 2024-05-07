using AutoMapper;
using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;

namespace InstaConnect.Follows.Business.Commands.Follows.AddFollow;

public class AddFollowCommandHandler : ICommandHandler<AddFollowCommand>
{
    private const string USER_ALREADY_FOLLOWED = "This user has already been followed";

    private readonly IMapper _mapper;
    private readonly IFollowRepository _followRepository;
    private readonly IGetCurrentUserRequestClient _requestClient;
    private readonly IValidateUserByIdRequestClient _validateUserByIdRequestClient;

    public AddFollowCommandHandler(
        IMapper mapper,
        IFollowRepository followRepository,
        IGetCurrentUserRequestClient requestClient,
        IValidateUserByIdRequestClient validateUserByIdRequestClient)
    {
        _mapper = mapper;
        _followRepository = followRepository;
        _requestClient = requestClient;
        _validateUserByIdRequestClient = validateUserByIdRequestClient;
    }

    public async Task Handle(AddFollowCommand request, CancellationToken cancellationToken)
    {
        var getCurrentUserRequest = _mapper.Map<GetCurrentUserRequest>(request);
        var getCurrentUserResponse = await _requestClient.GetResponse<GetCurrentUserResponse>(getCurrentUserRequest, cancellationToken);

        var getUserByFollowingIdRequest = _mapper.Map<ValidateUserByIdRequest>(request);
        var getUserByFollowingIdResponse = await _requestClient.GetResponse<GetCurrentUserResponse>(getUserByFollowingIdRequest, cancellationToken);

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
