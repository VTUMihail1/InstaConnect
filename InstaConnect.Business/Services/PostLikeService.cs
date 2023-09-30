using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Extensions;
using InstaConnect.Business.Models.DTOs.PostLike;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Business.Services
{
    public class PostLikeService : IPostLikeService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IPostLikeRepository _postLikeRepository;
        private readonly IPostRepository _postRepository;
        private readonly UserManager<User> _userManager;

        public PostLikeService(
            IMapper mapper,
            IResultFactory resultFactory,
            IPostLikeRepository postLikeRepository,
            IPostRepository postRepository,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _postLikeRepository = postLikeRepository;
            _postRepository = postRepository;
            _userManager = userManager;
        }

        public async Task<ICollection<PostLikeResultDTO>> GetAllAsync(
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

            return postLikeResultDTOs;
        }

        public async Task<IResult<PostLikeResultDTO>> GetByIdAsync(string id)
        {
            var existingPostLike = await _postLikeRepository.FindEntityAsync(pl => pl.Id == id);

            if (existingPostLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

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
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }

            var postLikeResultDTO = _mapper.Map<PostLikeResultDTO>(existingPostLike);
            var okResult = _resultFactory.GetOkResult(postLikeResultDTO);

            return okResult;
        }

        public async Task<IResult<PostLikeResultDTO>> AddAsync(string currentUserId, PostLikeAddDTO postLikeAddDTO)
        {
            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUser, postLikeAddDTO.UserId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<PostLikeResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            var existingUser = await _userManager.FindByIdAsync(postLikeAddDTO.UserId);

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

        public async Task<IResult<PostLikeResultDTO>> DeleteByUserIdAndPostIdAsync(string currentUserId, string userId, string postId)
        {
            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUser, userId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<PostLikeResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            var existingPostLike = await _postLikeRepository.FindEntityAsync(pl => pl.UserId == userId && pl.PostId == postId);

            if (existingPostLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }

            await _postLikeRepository.DeleteAsync(existingPostLike);

            var noContentResult = _resultFactory.GetNoContentResult<PostLikeResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostLikeResultDTO>> DeleteAsync(string currentUserId, string id)
        {
            var existingPostLike = await _postLikeRepository.FindEntityAsync(pl => pl.Id == id);

            if (existingPostLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }

            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUser, existingPostLike.UserId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<PostLikeResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            await _postLikeRepository.DeleteAsync(existingPostLike);

            var noContentResult = _resultFactory.GetNoContentResult<PostLikeResultDTO>();

            return noContentResult;
        }
    }
}
