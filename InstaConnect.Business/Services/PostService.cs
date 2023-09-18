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

        public async Task<ICollection<PostResultDTO>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            var postResultDTOs = _mapper.Map<ICollection<PostResultDTO>>(posts);

            return postResultDTOs;
        }

        public async Task<ICollection<PostResultDTO>> GetAllByUserIdAsync(string userId)
        {
            var posts = await _postRepository.GetAllFilteredAsync(p => p.UserId == userId);
            var postResultDTOs = _mapper.Map<ICollection<PostResultDTO>>(posts);

            return postResultDTOs;
        }

        public async Task<IResult<PostResultDTO>> GetByIdAsync(string id)
        {
            var post = await _postRepository.FindEntityAsync(p => p.Id == id);

            if (post == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostResultDTO>(InstaConnectErrorMessages.PostNotFound);

                return notFoundResult;
            }

            var postResultDTO = _mapper.Map<PostResultDTO>(post);
            var okResult = _resultFactory.GetOkResult(postResultDTO);

            return okResult;
        }

        public async Task<IResult<PostResultDTO>> AddAsync(PostAddDTO postAddDTO)
        {
            var existingUser = await _userManager.FindByIdAsync(postAddDTO.UserId);

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

        public async Task<IResult<PostResultDTO>> UpdateAsync(string id, PostUpdateDTO postUpdateDTO)
        {
            var post = await _postRepository.FindEntityAsync(p => p.Id == id);

            if (post == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostResultDTO>(InstaConnectErrorMessages.PostNotFound);

                return notFoundResult;
            }

            _mapper.Map(postUpdateDTO, post);
            await _postRepository.UpdateAsync(post);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostResultDTO>> DeleteAsync(string id)
        {
            var post = await _postRepository.FindEntityAsync(p => p.Id == id);

            if (post == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostResultDTO>(InstaConnectErrorMessages.PostNotFound);

                return notFoundResult;
            }

            await _postRepository.DeleteAsync(post);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }
    }
}
