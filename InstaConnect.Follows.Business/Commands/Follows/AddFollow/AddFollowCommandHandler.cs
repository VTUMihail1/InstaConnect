﻿using AutoMapper;
using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;

namespace InstaConnect.Follows.Business.Commands.Follows.AddFollow
{
    public class AddFollowCommandHandler : ICommandHandler<AddFollowCommand>
    {
        private const string USER_ALREADY_FOLLOWED = "This user has already been followed";

        private readonly IMapper _mapper;
        private readonly IFollowRepository _followRepository;
        private readonly IValidateUserIdRequestClient _requestClient;

        public AddFollowCommandHandler(
            IMapper mapper,
            IFollowRepository followRepository,
            IValidateUserIdRequestClient requestClient)
        {
            _mapper = mapper;
            _followRepository = followRepository;
            _requestClient = requestClient;
        }

        public async Task Handle(AddFollowCommand request, CancellationToken cancellationToken)
        {
            var getUserByFollowerIdRequest = _mapper.Map<ValidateUserIdRequest>(request);
            var getUserByFollowerIdResponse = await _requestClient.GetResponse<GetCurrentUserResponse>(getUserByFollowerIdRequest, cancellationToken);

            if (!getUserByFollowerIdResponse.Message.Exists)
            {
                throw new UserNotFoundException();
            }

            var getUserByFollowingIdRequest = _mapper.Map<ValidateUserIdRequest>(request);
            var getUserByFollowingIdResponse = await _requestClient.GetResponse<GetCurrentUserResponse>(getUserByFollowingIdRequest, cancellationToken);

            if (!getUserByFollowingIdResponse.Message.Exists)
            {
                throw new UserNotFoundException();
            }

            var existingPostLike = _followRepository.GetByFollowerIdAndFollowingIdAsync(request.FollowerId, request.FollowingId, cancellationToken);

            if (existingPostLike == null)
            {
                throw new BadRequestException(USER_ALREADY_FOLLOWED);
            }

            var follow = _mapper.Map<Follow>(request);
            await _followRepository.AddAsync(follow, cancellationToken);
        }
    }
}
