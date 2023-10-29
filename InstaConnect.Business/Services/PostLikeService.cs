using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.PostLike;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.Services
{
    public class PostLikeService : IPostLikeService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IPostLikeRepository _postLikeRepository;
        private readonly IPostRepository _postRepository;
        private readonly IInstaConnectUserManager _instaConnectUserManager;

        public PostLikeService(
            IMapper mapper,
            IResultFactory resultFactory,
            IPostLikeRepository postLikeRepository,
            IPostRepository postRepository,
            IInstaConnectUserManager instaConnectUserManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _postLikeRepository = postLikeRepository;
            _postRepository = postRepository;
            _instaConnectUserManager = instaConnectUserManager;
        }

        public async Task<IResult<ICollection<PostLikeResultDTO>>> GetAllAsync(
            string userId,
            string postId,
            int page,
            int amount)
        {
            var skipAmount = (page - 1) * amount;

            var postLikes = await _postLikeRepository.GetAllAsync(pl =>
            (userId == default || pl.UserId == userId) &&
            (postId == default || pl.PostId == postId));

            var postLikeResultDTOs = _mapper.Map<ICollection<PostLikeResultDTO>>(postLikes);
            var okResult = _resultFactory.GetOkResult(postLikeResultDTOs);

            return okResult;
        }

        public async Task<IResult<PostLikeResultDTO>> GetByIdAsync(string id)
        {
            var existingPostLike = await _postLikeRepository.FindEntityAsync(pl => pl.Id == id);

            if (existingPostLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>();

                return notFoundResult;
            }

            var postLikeResultDTO = _mapper.Map<PostLikeResultDTO>(existingPostLike);
            var okResult = _resultFactory.GetOkResult(postLikeResultDTO);

            return okResult;
        }

        public async Task<IResult<PostLikeResultDTO>> GetByUserIdAndPostIdAsync(string userId, string postId)
        {
            var existingPostLike = await _postLikeRepository.FindEntityAsync(pl => pl.UserId == userId && pl.PostId == postId);

            if (existingPostLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>();

                return notFoundResult;
            }

            var postLikeResultDTO = _mapper.Map<PostLikeResultDTO>(existingPostLike);
            var okResult = _resultFactory.GetOkResult(postLikeResultDTO);

            return okResult;
        }

        public async Task<IResult<PostLikeResultDTO>> AddAsync(PostLikeAddDTO postLikeAddDTO)
        {
            var existingUser = await _instaConnectUserManager.FindByIdAsync(postLikeAddDTO.UserId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostLikeResultDTO>(InstaConnectErrorMessages.UserNotFound);

                return badRequestResult;
            }

            var existingPost = await _postRepository.FindEntityAsync(p => p.Id == postLikeAddDTO.PostId);

            if (existingPost == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostLikeResultDTO>();

                return badRequestResult;
            }

            var existingPostLike = await _postLikeRepository.FindEntityAsync(pl => pl.UserId == postLikeAddDTO.UserId && pl.PostId == postLikeAddDTO.PostId);

            if (existingPostLike != null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostLikeResultDTO>(InstaConnectErrorMessages.LikeAlreadyExists);

                return badRequestResult;
            }

            var postLike = _mapper.Map<PostLike>(postLikeAddDTO);
            await _postLikeRepository.AddAsync(postLike);

            var noContentResult = _resultFactory.GetNoContentResult<PostLikeResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostLikeResultDTO>> DeleteByUserIdAndPostIdAsync(string userId, string postId)
        {
            var existingPostLike = await _postLikeRepository.FindEntityAsync(pl => pl.UserId == userId && pl.PostId == postId);

            if (existingPostLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>();

                return notFoundResult;
            }

            await _postLikeRepository.DeleteAsync(existingPostLike);

            var noContentResult = _resultFactory.GetNoContentResult<PostLikeResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostLikeResultDTO>> DeleteAsync(string userId, string id)
        {
            var existingPostLike = await _postLikeRepository.FindEntityAsync(pl => pl.Id == id && pl.UserId == userId);

            if (existingPostLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>();

                return notFoundResult;
            }

            await _postLikeRepository.DeleteAsync(existingPostLike);

            var noContentResult = _resultFactory.GetNoContentResult<PostLikeResultDTO>();

            return noContentResult;
        }
    }
}
