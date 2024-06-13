using AutoMapper;
using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.Models.Users;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Follows.Business.Commands.Follows.AddFollow;

internal class AddFollowCommandHandler : ICommandHandler<AddFollowCommand>
{
    private const string USER_ALREADY_FOLLOWED = "This user has already been followed";

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFollowRepository _followRepository;
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IRequestClient<GetUserByIdRequest> _getUserByIdRequestClient;

    public AddFollowCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IFollowRepository followRepository,
        ICurrentUserContext currentUserContext,
        IRequestClient<GetUserByIdRequest> getUserByIdRequestClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _followRepository = followRepository;
        _currentUserContext = currentUserContext;
        _getUserByIdRequestClient = getUserByIdRequestClient;
    }

    public async Task Handle(AddFollowCommand request, CancellationToken cancellationToken)
    {
        var getUserByIdRequest = _mapper.Map<GetUserByIdRequest>(request);
        var getUserByIdResponse = await _getUserByIdRequestClient.GetResponse<GetUserByIdResponse>(getUserByIdRequest, cancellationToken);

        if(getUserByIdResponse == null)
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
    }
}
