using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
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

        public async Task<ICollection<FollowResultDTO>> GetAllByFollowerIdAsync(string followerId)
        {
            var followers = await _followRepository.GetAllFilteredAsync(p => p.FollowerId == followerId);
            var followersResultDTOs = _mapper.Map<ICollection<FollowResultDTO>>(followers);

            return followersResultDTOs;
        }

        public async Task<ICollection<FollowResultDTO>> GetAllByFollowingIdAsync(string followingId)
        {
            var followers = await _followRepository.GetAllFilteredAsync(p => p.FollowingId == followingId);
            var followersResultDTOs = _mapper.Map<ICollection<FollowResultDTO>>(followers);

            return followersResultDTOs;
        }

        public async Task<IResult<FollowResultDTO>> AddAsync(FollowAddDTO followAddDTO)
        {
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

            var existingFollow = await _followRepository.FindEntityAsync(l => l.FollowerId == followAddDTO.FollowerId && l.FollowingId == followAddDTO.FollowingId);

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

        public async Task<IResult<FollowResultDTO>> DeleteByFollowerIdAndFollowingIdAsync(string followingId, string followerId)
        {
            var existingFollow = await _followRepository.FindEntityAsync(l => l.FollowingId == followingId && l.FollowerId == followerId);

            if (existingFollow == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<FollowResultDTO>(InstaConnectErrorMessages.FollowNotFound);

                return notFoundResult;
            }

            await _followRepository.DeleteAsync(existingFollow);

            var noContentResult = _resultFactory.GetNoContentResult<FollowResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<FollowResultDTO>> DeleteAsync(string id)
        {
            var existingFollow = await _followRepository.FindEntityAsync(l => l.Id == id);

            if (existingFollow == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<FollowResultDTO>(InstaConnectErrorMessages.FollowNotFound);

                return notFoundResult;
            }

            await _followRepository.DeleteAsync(existingFollow);

            var noContentResult = _resultFactory.GetNoContentResult<FollowResultDTO>();

            return noContentResult;
        }
    }
}
