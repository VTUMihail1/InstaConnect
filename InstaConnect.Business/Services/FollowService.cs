using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.Services
{
    public class FollowService : IFollowService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IFollowRepository _followRepository;
        private readonly IUserRepository _userRepository;

        public FollowService(
            IMapper mapper,
            IResultFactory resultFactory,
            IFollowRepository followRepository,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _followRepository = followRepository; ;
            _userRepository = userRepository;
        }

        public async Task<IResult<ICollection<FollowResultDTO>>> GetAllAsync(string followerId, string followingId, int page, int amount)
        {
            var skipAmount = (page - 1) * amount;

            var followers = await _followRepository.GetAllAsync(f =>
            (followerId == default || f.FollowerId == followerId) &&
            (followingId == default || f.FollowingId == followingId),
            skipAmount,
            amount);

            var followResultDTOs = _mapper.Map<ICollection<FollowResultDTO>>(followers);
            var okResult = _resultFactory.GetOkResult(followResultDTOs);

            return okResult;
        }

        public async Task<IResult<FollowResultDTO>> GetByIdAsync(string id)
        {
            var existingFollow = await _followRepository.FindEntityAsync(f => f.Id == id);

            if (existingFollow == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<FollowResultDTO>();

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
                var notFoundResult = _resultFactory.GetNotFoundResult<FollowResultDTO>();

                return notFoundResult;
            }

            var followResultDTO = _mapper.Map<FollowResultDTO>(existingFollow);
            var okResult = _resultFactory.GetOkResult(followResultDTO);

            return okResult;
        }

        public async Task<IResult<FollowResultDTO>> AddAsync(FollowAddDTO followAddDTO)
        {
            var existingFollower = await _userRepository.FindEntityAsync(f => f.Id == followAddDTO.FollowerId);

            if (existingFollower == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<FollowResultDTO>(InstaConnectErrorMessages.FollowerNotFound);

                return badRequestResult;
            }

            var existingFollowing = await _userRepository.FindEntityAsync(f => f.Id == followAddDTO.FollowingId);

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

        public async Task<IResult<FollowResultDTO>> DeleteByFollowerIdAndFollowingIdAsync(string followerId, string followingId)
        {
            var existingFollow = await _followRepository.FindEntityAsync(f => f.FollowingId == followingId && f.FollowerId == followerId);

            if (existingFollow == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<FollowResultDTO>();

                return notFoundResult;
            }

            await _followRepository.DeleteAsync(existingFollow);

            var noContentResult = _resultFactory.GetNoContentResult<FollowResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<FollowResultDTO>> DeleteAsync(string followerId, string id)
        {
            var existingFollow = await _followRepository.FindEntityAsync(f => f.Id == id && f.FollowerId == followerId);

            if (existingFollow == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<FollowResultDTO>();

                return notFoundResult;
            }

            await _followRepository.DeleteAsync(existingFollow);

            var noContentResult = _resultFactory.GetNoContentResult<FollowResultDTO>();

            return noContentResult;
        }
    }
}
