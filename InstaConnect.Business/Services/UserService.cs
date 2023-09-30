using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Extensions;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.DTOs.User;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(
            IMapper mapper,
            IResultFactory resultFactory,
            IUserRepository userRepository,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<ICollection<UserResultDTO>> GetAllAsync(
            string firstName, 
            string lastName, 
            int page,
            int amount)
        {
			var skipAmount = (page - 1) * amount;

			var users = await _userRepository.GetAllAsync(u =>
            (firstName == default || u.FirstName == firstName) &&
            (lastName == default || u.LastName == lastName),
            skipAmount,
            amount);

            var userResultDTOs = _mapper.Map<ICollection<UserResultDTO>>(users);

            return userResultDTOs;
        }

        public async Task<IResult<UserResultDTO>> GetByIdAsync(string username)
        {
            var existingUser = await _userRepository.FindEntityAsync(u => u.UserName == username);

            if (existingUser == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<UserResultDTO>(InstaConnectErrorMessages.UserNotFound);
            }

            var userResultDTO = _mapper.Map<UserResultDTO>(existingUser);
            var okResult = _resultFactory.GetOkResult(userResultDTO);

            return okResult;
        }

        public async Task<IResult<UserResultDTO>> GetByUsernameAsync(string username)
        {
            var existingUser = await _userRepository.FindEntityAsync(u => u.UserName == username);

            if (existingUser == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<UserResultDTO>(InstaConnectErrorMessages.UserNotFound);
            }

            var userResultDTO = _mapper.Map<UserResultDTO>(existingUser);
            var okResult = _resultFactory.GetOkResult(userResultDTO);

            return okResult;
        }

        public async Task<IResult<UserPersonalResultDTO>> GetPersonalByIdAsync(string currentUserId, string id)
        {
            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUser, id);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<UserPersonalResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);
                return forbiddenResult;
            }

            var existingUser = await _userRepository.FindEntityAsync(u => u.Id == id);

            if (existingUser == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<UserResultDTO>(InstaConnectErrorMessages.UserNotFound);
            }

            var userPersonalResultDTO = _mapper.Map<UserPersonalResultDTO>(existingUser);
            var okResult = _resultFactory.GetOkResult(userPersonalResultDTO);

            return okResult;
        }
    }
}
