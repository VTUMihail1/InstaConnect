using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
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

        public async Task<ICollection<PostLikeResultDTO>> GetAllAsync()
        {
            var postLikes = await _postLikeRepository.GetAllIncludedAsync();
            var postLikeResultDTOs = _mapper.Map<ICollection<PostLikeResultDTO>>(postLikes);

            return postLikeResultDTOs;
        }

        public async Task<ICollection<PostLikeResultDTO>> GetAllByUserIdAsync(string userId)
        {
            var postLikes = await _postLikeRepository.GetAllFilteredIncludedAsync(pl => pl.UserId == userId);
            var postLikeResultDTOs = _mapper.Map<ICollection<PostLikeResultDTO>>(postLikes);

            return postLikeResultDTOs;
        }

        public async Task<ICollection<PostLikeResultDTO>> GetAllByPostIdAsync(string postId)
        {
            var postLikes = await _postLikeRepository.GetAllFilteredIncludedAsync(pl => pl.PostId == postId);
            var postLikeResultDTOs = _mapper.Map<ICollection<PostLikeResultDTO>>(postLikes);

            return postLikeResultDTOs;
        }

        public async Task<IResult<PostLikeResultDTO>> GetByIdAsync(string id)
        {
            var existingPostLike = await _postLikeRepository.FindPostLikeIncludedAsync(pl => pl.Id == id);

            if (existingPostLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }
            var postLikeResultDTO = _mapper.Map<PostLikeResultDTO>(existingPostLike);
            var okResult = _resultFactory.GetOkResult(postLikeResultDTO);

            return okResult;
        }

        public async Task<IResult<PostLikeResultDTO>> GetByPostIdAndUserIdAsync(string userId, string postId)
        {
            var existingPostLike = await _postLikeRepository.FindPostLikeIncludedAsync(pl => pl.UserId == userId && pl.PostId == postId);

            if (existingPostLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }
            var postLikeResultDTO = _mapper.Map<PostLikeResultDTO>(existingPostLike);
            var okResult = _resultFactory.GetOkResult(postLikeResultDTO);

            return okResult;
        }

        public async Task<IResult<PostLikeResultDTO>> AddAsync(PostLikeAddDTO postLikeAddDTO)
        {
            var existingUser = await _userManager.FindByIdAsync(postLikeAddDTO.UserId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostLikeResultDTO>();

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

        public async Task<IResult<PostLikeResultDTO>> DeleteByPostIdAndUserIdAsync(string userId, string postId)
        {
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

        public async Task<IResult<PostLikeResultDTO>> DeleteAsync(string id)
        {
            var existingPostLike = await _postLikeRepository.FindEntityAsync(pl => pl.Id == id);

            if (existingPostLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }

            await _postLikeRepository.DeleteAsync(existingPostLike);

            var noContentResult = _resultFactory.GetNoContentResult<PostLikeResultDTO>();

            return noContentResult;
        }
    }
}
