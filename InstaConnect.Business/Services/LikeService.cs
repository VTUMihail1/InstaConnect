using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Like;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Business.Services
{
    public class LikeService : ILikeService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly ILikeRepository _likeRepository;
        private readonly IPostRepository _postRepository;
        private readonly UserManager<User> _userManager;

        public LikeService(
            IMapper mapper,
            IResultFactory resultFactory,
            ILikeRepository likeRepository,
            IPostRepository postRepository,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _likeRepository = likeRepository;
            _postRepository = postRepository;
            _userManager = userManager;
        }

        public async Task<ICollection<LikeResultDTO>> GetAllByUserIdAsync(string userId)
        {
            var likes = await _likeRepository.GetAllFilteredAsync(p => p.UserId == userId);
            var likeResultDTOs = _mapper.Map<ICollection<LikeResultDTO>>(likes);

            return likeResultDTOs;
        }

        public async Task<ICollection<LikeResultDTO>> GetAllByPostIdAsync(string postId)
        {
            var likes = await _likeRepository.GetAllFilteredAsync(p => p.PostId == postId);
            var likeResultDTOs = _mapper.Map<ICollection<LikeResultDTO>>(likes);

            return likeResultDTOs;
        }

        public async Task<IResult<LikeResultDTO>> AddAsync(LikeAddDTO likeAddDTO)
        {
            var existingUser = await _userManager.FindByIdAsync(likeAddDTO.UserId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<LikeResultDTO>();

                return badRequestResult;
            }

            var existingPost = await _postRepository.FindEntityAsync(p => p.Id == likeAddDTO.PostId);

            if (existingPost == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<LikeResultDTO>();

                return badRequestResult;
            }

            var existingLike = await _likeRepository.FindEntityAsync(l => l.UserId == likeAddDTO.UserId && l.PostId == likeAddDTO.PostId);

            if (existingLike != null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<LikeResultDTO>(InstaConnectErrorMessages.LikeAlreadyExists);

                return badRequestResult;
            }

            var like = _mapper.Map<Like>(likeAddDTO);
            await _likeRepository.AddAsync(like);

            var noContentResult = _resultFactory.GetNoContentResult<LikeResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<LikeResultDTO>> DeleteAsync(string userId, string postId)
        {
            var like = await _likeRepository.FindEntityAsync(l => l.UserId == userId && l.PostId == postId);

            if (like == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<LikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }

            await _likeRepository.DeleteAsync(like);

            var noContentResult = _resultFactory.GetNoContentResult<LikeResultDTO>();

            return noContentResult;
        }
    }
}
