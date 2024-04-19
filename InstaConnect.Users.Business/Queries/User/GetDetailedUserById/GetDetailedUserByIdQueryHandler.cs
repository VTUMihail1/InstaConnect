using AutoMapper;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Queries.User.GetDetailedUserById
{
    public class GetDetailedUserByIdQueryHandler : IQueryHandler<GetDetailedUserByIdQuery, UserDetailedViewDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetDetailedUserByIdQueryHandler(
            IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDetailedViewDTO> Handle(GetDetailedUserByIdQuery request, CancellationToken cancellationToken)
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
}
