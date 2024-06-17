using AutoMapper;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Queries.User.GetUserByName;

public class GetUserByNameQueryHandler : IQueryHandler<GetUserByNameQuery, UserViewModel>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetUserByNameQueryHandler(
        IMapper mapper,
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserViewModel> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByNameAsync(request.UserName, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var response = _mapper.Map<UserViewModel>(existingUser);

        return response;
    }
}
