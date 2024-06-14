using AutoMapper;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Queries.User.GetUserDetailedById;

public class GetUserDetailedByIdQueryHandler : IQueryHandler<GetUserDetailedByIdQuery, UserDetailedViewDTO>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetUserDetailedByIdQueryHandler(
        IMapper mapper,
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserDetailedViewDTO> Handle(GetUserDetailedByIdQuery request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var userDetailedViewDTO = _mapper.Map<UserDetailedViewDTO>(existingUser);

        return userDetailedViewDTO;
    }
}
