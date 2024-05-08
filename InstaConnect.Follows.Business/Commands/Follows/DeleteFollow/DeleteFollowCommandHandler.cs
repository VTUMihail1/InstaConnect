using AutoMapper;
using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Shared.Business.Exceptions.Follow;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using MassTransit;

namespace InstaConnect.Follows.Business.Commands.Follows.DeleteFollow;

public class DeleteFollowCommandHandler : ICommandHandler<DeleteFollowCommand>
{
    private readonly IMapper _mapper;
    private readonly IFollowRepository _followRepository;
    private readonly IRequestClient<ValidateUserByIdRequest> _validateUserByIdRequestClient;

    public DeleteFollowCommandHandler(
        IMapper mapper,
        IFollowRepository followRepository,
        IRequestClient<ValidateUserByIdRequest> validateUserByIdRequestClient)
    {
        _mapper = mapper;
        _followRepository = followRepository;
        _validateUserByIdRequestClient = validateUserByIdRequestClient;
    }

    public async Task Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
    {
        var existingFollow = await _followRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingFollow == null)
        {
            throw new FollowNotFoundException();
        }

        var validateUserByIdRequest = _mapper.Map<ValidateUserByIdRequest>(existingFollow);
        await _validateUserByIdRequestClient.GetResponse<ValidateUserByIdResponse>(validateUserByIdRequest, cancellationToken);

        await _followRepository.DeleteAsync(existingFollow, cancellationToken);
    }
}
