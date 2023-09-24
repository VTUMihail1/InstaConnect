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

        public async Task<ICollection<PostLikeDetailedDTO>> GetAllDetailedAsync()
        {
            var postLikes = await _postLikeRepository.GetAllIncludedAsync();
            var postLikeDetailedDTOs = _mapper.Map<ICollection<PostLikeDetailedDTO>>(postLikes);
            return postLikeDetailedDTOs;
        }

        public async Task<ICollection<PostLikeDetailedDTO>> GetAllDetailedByUserIdAsync(string userId)
        {
            var postLikes = await _postLikeRepository.GetAllFilteredIncludedAsync(p => p.UserId == userId);
            var postLikeDetailedDTOs = _mapper.Map<ICollection<PostLikeDetailedDTO>>(postLikes);
            return postLikeDetailedDTOs;
        }

        public async Task<ICollection<PostLikeDetailedDTO>> GetAllDetailedByPostIdAsync(string postId)
        {
            var postLikes = await _postLikeRepository.GetAllFilteredIncludedAsync(p => p.PostId == postId);
            var postLikeDetailedDTOs = _mapper.Map<ICollection<PostLikeDetailedDTO>>(postLikes);
            return postLikeDetailedDTOs;
        }

        public async Task<IResult<PostLikeDetailedDTO>> GetDetailedByIdAsync(string id)
        {
            var postLike = await _postLikeRepository.FindIncludedAsync(p => p.Id == id);
            if (postLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeDetailedDTO>(InstaConnectErrorMessages.LikeNotFound);
                return notFoundResult;
            }
            var postLikeDetailedDTO = _mapper.Map<PostLikeDetailedDTO>(postLike);
            var okResult = _resultFactory.GetOkResult(postLikeDetailedDTO);
            return okResult;
        }

        public async Task<ICollection<PostLikeResultDTO>> GetAllAsync()
        {
            var postLikes = await _postLikeRepository.GetAllAsync();
            var postLikeResultDTOs = _mapper.Map<ICollection<PostLikeResultDTO>>(postLikes);
            return postLikeResultDTOs;
        }

        public async Task<ICollection<PostLikeResultDTO>> GetAllByUserIdAsync(string userId)
        {
            var postLikes = await _postLikeRepository.GetAllFilteredAsync(p => p.UserId == userId);
            var postLikeResultDTOs = _mapper.Map<ICollection<PostLikeResultDTO>>(postLikes);
            return postLikeResultDTOs;
        }

        public async Task<ICollection<PostLikeResultDTO>> GetAllByPostIdAsync(string postId)
        {
            var postLikes = await _postLikeRepository.GetAllFilteredAsync(p => p.PostId == postId);
            var postLikeResultDTOs = _mapper.Map<ICollection<PostLikeResultDTO>>(postLikes);
            return postLikeResultDTOs;
        }

        public async Task<IResult<PostLikeResultDTO>> GetByIdAsync(string id)
        {
            var postLike = await _postLikeRepository.FindEntityAsync(p => p.Id == id);
            if (postLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);
                return notFoundResult;
            }
            var postLikeResultDTO = _mapper.Map<PostLikeResultDTO>(postLike);
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

            var existingPostLike = await _postLikeRepository.FindEntityAsync(l => l.UserId == postLikeAddDTO.UserId && l.PostId == postLikeAddDTO.PostId);

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
            var postLike = await _postLikeRepository.FindEntityAsync(l => l.UserId == userId && l.PostId == postId);

            if (postLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }

            await _postLikeRepository.DeleteAsync(postLike);

            var noContentResult = _resultFactory.GetNoContentResult<PostLikeResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostLikeResultDTO>> DeleteAsync(string id)
        {
            var postLike = await _postLikeRepository.FindEntityAsync(l => l.Id == id);

            if (postLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }

            await _postLikeRepository.DeleteAsync(postLike);

            var noContentResult = _resultFactory.GetNoContentResult<PostLikeResultDTO>();

            return noContentResult;
        }
    }
}
