﻿using AutoMapper;
using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Shared.Business.Exceptions.Follow;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;

namespace InstaConnect.Follows.Business.Commands.Follows.DeleteFollow;

public class DeleteFollowCommandHandler : ICommandHandler<DeleteFollowCommand>
{
    private readonly IMapper _mapper;
    private readonly IFollowRepository _followRepository;
    private readonly IValidateUserByIdRequestClient _requestClient;

    public DeleteFollowCommandHandler(
        IMapper mapper,
        IFollowRepository followRepository,
        IValidateUserByIdRequestClient requestClient)
    {
        _mapper = mapper;
        _followRepository = followRepository;
        _requestClient = requestClient;
    }

    public async Task Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
    {
        var existingFollow = await _followRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingFollow == null)
        {
            throw new FollowNotFoundException();
        }

        var validateUserByIdRequest = _mapper.Map<ValidateUserByIdRequest>(existingFollow);
        await _requestClient.GetResponse<ValidateUserByIdResponse>(validateUserByIdRequest, cancellationToken);

        await _followRepository.DeleteAsync(existingFollow, cancellationToken);
    }
}
