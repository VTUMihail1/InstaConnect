﻿using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Extensions;
using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Business.Services
{
    public class FollowService : IFollowService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IFollowRepository _followRepository;
        private readonly UserManager<User> _userManager;

        public FollowService(
            IMapper mapper,
            IResultFactory resultFactory,
            IFollowRepository followRepository,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _followRepository = followRepository;
            _userManager = userManager;
        }

        public async Task<ICollection<FollowResultDTO>> GetAllAsync(string followerId, string followingId)
        {
            var followers = await _followRepository.GetAllAsync(f =>
            (followerId == default || f.FollowerId == followerId) &&
            (followingId == default || f.FollowingId == followingId));

            var followResultDTOs = _mapper.Map<ICollection<FollowResultDTO>>(followers);

            return followResultDTOs;
        }

        public async Task<IResult<FollowResultDTO>> GetByIdAsync(string id)
        {
            var existingFollow = await _followRepository.FindEntityAsync(f => f.Id == id);

            if (existingFollow == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<FollowResultDTO>(InstaConnectErrorMessages.FollowNotFound);

                return notFoundResult;
            }

            var followResultDTO = _mapper.Map<FollowResultDTO>(existingFollow);
            var okResult = _resultFactory.GetOkResult(followResultDTO);

            return okResult;
        }

        public async Task<IResult<FollowResultDTO>> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId)
        {
            var existingFollow = await _followRepository.FindEntityAsync(f => f.FollowerId == followerId && f.FollowingId == followingId);

            if (existingFollow == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<FollowResultDTO>(InstaConnectErrorMessages.FollowNotFound);

                return notFoundResult;
            }

            var followResultDTO = _mapper.Map<FollowResultDTO>(existingFollow);
            var okResult = _resultFactory.GetOkResult(followResultDTO);

            return okResult;
        }

        public async Task<IResult<FollowResultDTO>> AddAsync(string currentUserId, FollowAddDTO followAddDTO)
        {
            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUser, followAddDTO.FollowerId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<FollowResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            var existingFollower = await _userManager.FindByIdAsync(followAddDTO.FollowerId);

            if (existingFollower == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<FollowResultDTO>(InstaConnectErrorMessages.FollowerNotFound);

                return badRequestResult;
            }

            var existingFollowing = await _userManager.FindByIdAsync(followAddDTO.FollowingId);

            if (existingFollowing == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<FollowResultDTO>(InstaConnectErrorMessages.FollowingNotFound);

                return badRequestResult;
            }

            var existingFollow = await _followRepository.FindEntityAsync(f => f.FollowerId == followAddDTO.FollowerId && f.FollowingId == followAddDTO.FollowingId);

            if (existingFollow != null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<FollowResultDTO>(InstaConnectErrorMessages.FollowAlreadyExists);

                return badRequestResult;
            }

            var follow = _mapper.Map<Follow>(followAddDTO);
            await _followRepository.AddAsync(follow);

            var noContentResult = _resultFactory.GetNoContentResult<FollowResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<FollowResultDTO>> DeleteByFollowerIdAndFollowingIdAsync(string currentUserId, string followerId, string followingId)
        {
            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUser, followerId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<FollowResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            var existingFollow = await _followRepository.FindEntityAsync(f => f.FollowingId == followingId && f.FollowerId == followerId);

            if (existingFollow == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<FollowResultDTO>(InstaConnectErrorMessages.FollowNotFound);

                return notFoundResult;
            }

            await _followRepository.DeleteAsync(existingFollow);

            var noContentResult = _resultFactory.GetNoContentResult<FollowResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<FollowResultDTO>> DeleteAsync(string currentUserId, string id)
        {
            var existingFollow = await _followRepository.FindEntityAsync(f => f.Id == id);

            if (existingFollow == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<FollowResultDTO>(InstaConnectErrorMessages.FollowNotFound);

                return notFoundResult;
            }

            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUser, existingFollow.FollowerId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<FollowResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            await _followRepository.DeleteAsync(existingFollow);

            var noContentResult = _resultFactory.GetNoContentResult<FollowResultDTO>();

            return noContentResult;
        }
    }
}
