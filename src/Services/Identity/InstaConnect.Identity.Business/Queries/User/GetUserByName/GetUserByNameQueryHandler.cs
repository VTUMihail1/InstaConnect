using AutoMapper;
using InstaConnect.Identity.Business.Models;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.User;

namespace InstaConnect.Identity.Business.Queries.User.GetUserByName;

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
