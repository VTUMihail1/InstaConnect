using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Business.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IPostRepository _postRepository;
        private readonly UserManager<User> _userManager;

        public PostService(
            IMapper mapper,
            IResultFactory resultFactory,
            IPostRepository postRepository,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _postRepository = postRepository;
            _userManager = userManager;
        }

        public async Task<IResult<ICollection<PostResultDTO>>> GetAllAsync(
            string userId,
            int page,
            int amount)
        {
            var skipAmount = (page - 1) * amount;

            var posts = await _postRepository.GetAllAsync(
                p => userId == default || p.UserId == userId,
                skipAmount,
                amount);

            var postResultDTOs = _mapper.Map<ICollection<PostResultDTO>>(posts);
            var okResult = _resultFactory.GetOkResult(postResultDTOs);

            return okResult;
        }

        public async Task<IResult<PostResultDTO>> GetByIdAsync(string id)
        {
            var existingPost = await _postRepository.FindEntityAsync(p => p.Id == id);

            if (existingPost == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostResultDTO>(InstaConnectErrorMessages.PostNotFound);

                return notFoundResult;
            }

            var postResultDTO = _mapper.Map<PostResultDTO>(existingPost);
            var okResult = _resultFactory.GetOkResult(postResultDTO);

            return okResult;
        }

        public async Task<IResult<PostResultDTO>> AddAsync(string currentUserId, PostAddDTO postAddDTO)
        {
            var doesNotHavePermission = currentUserId != postAddDTO.UserId;

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<PostResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            var existingUser = _userManager.FindByIdAsync(postAddDTO.UserId);

            if (existingUser == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostResultDTO>(InstaConnectErrorMessages.UserNotFound);

                return notFoundResult;
            }

            var post = _mapper.Map<Post>(postAddDTO);
            await _postRepository.AddAsync(post);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostResultDTO>> UpdateAsync(string currentUserId, string id, PostUpdateDTO postUpdateDTO)
        {
            var existingPost = await _postRepository.FindEntityAsync(p => p.Id == id);

            if (existingPost == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostResultDTO>(InstaConnectErrorMessages.PostNotFound);

                return notFoundResult;
            }

            var doesNotHavePermission = currentUserId != existingPost.UserId;

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<PostResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            _mapper.Map(postUpdateDTO, existingPost);
            await _postRepository.UpdateAsync(existingPost);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostResultDTO>> DeleteAsync(string currentUserId, string id)
        {
            var existingPost = await _postRepository.FindEntityAsync(p => p.Id == id);

            if (existingPost == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostResultDTO>(InstaConnectErrorMessages.PostNotFound);

                return notFoundResult;
            }

            var doesNotHavePermission = currentUserId != existingPost.UserId;

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<PostResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            await _postRepository.DeleteAsync(existingPost);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }
    }
}
