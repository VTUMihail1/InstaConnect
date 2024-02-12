using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.DTOs.PostLike;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAccountManager _accountManager;

        public PostService(
            IMapper mapper,
            IResultFactory resultFactory,
            IPostRepository postRepository,
            IUserRepository userRepository,
            IAccountManager accountManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _accountManager = accountManager;
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
                var notFoundResult = _resultFactory.GetNotFoundResult<PostResultDTO>();

                return notFoundResult;
            }

            var postResultDTO = _mapper.Map<PostResultDTO>(existingPost);
            var okResult = _resultFactory.GetOkResult(postResultDTO);

            return okResult;
        }

        public async Task<IResult<PostResultDTO>> AddAsync(string userId, PostAddDTO postAddDTO)
        {
            var validUser = _accountManager.ValidateUser(userId, postAddDTO.UserId);

            if (!validUser)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<PostResultDTO>();

                return forbiddenResult;
            }

            var existingUser = await _userRepository.FindEntityAsync(f => f.Id == postAddDTO.UserId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostResultDTO>(InstaConnectErrorMessages.UserNotFound);

                return badRequestResult;
            }

            var post = _mapper.Map<Post>(postAddDTO);
            await _postRepository.AddAsync(post);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostResultDTO>> UpdateAsync(string userId, string id, PostUpdateDTO postUpdateDTO)
        {
            var existingPost = await _postRepository.FindEntityAsync(p => p.Id == id);

            if (existingPost == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostResultDTO>();

                return notFoundResult;
            }

            var validUser = _accountManager.ValidateUser(userId, existingPost.UserId);

            if (!validUser)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<PostResultDTO>();

                return forbiddenResult;
            }

            _mapper.Map(postUpdateDTO, existingPost);
            await _postRepository.UpdateAsync(existingPost);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostResultDTO>> DeleteAsync(string userId, string id)
        {
            var existingPost = await _postRepository.FindEntityAsync(p => p.Id == id);

            if (existingPost == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostResultDTO>();

                return notFoundResult;
            }

            var validUser = _accountManager.ValidateUser(userId, existingPost.UserId);

            if (!validUser)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<PostResultDTO>();

                return forbiddenResult;
            }

            await _postRepository.DeleteAsync(existingPost);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }
    }
}
