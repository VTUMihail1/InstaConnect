﻿using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.User;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;

namespace InstaConnect.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IUserRepository _userRepository;

        public UserService(
            IMapper mapper,
            IResultFactory resultFactory,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _userRepository = userRepository;
        }

        public async Task<ICollection<UserResultDTO>> GetAllAsync(string firstName, string lastName)
        {
            var users = await _userRepository.GetAllAsync(u =>
            (firstName == default || u.FirstName == firstName) &&
            (lastName == default || u.LastName == lastName));

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
    }
}
