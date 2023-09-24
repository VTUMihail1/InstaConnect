using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Business.Services
{
    public class PostCommentService : IPostCommentService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IPostRepository _postRepository;
        private readonly UserManager<User> _userManager;

        public PostCommentService(
            IMapper mapper,
            IResultFactory resultFactory,
            IPostCommentRepository postCommentRepository,
            IPostRepository postRepository,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _postCommentRepository = postCommentRepository;
            _postRepository = postRepository;
            _userManager = userManager;
        }

        public async Task<ICollection<PostCommentResultDTO>> GetAllByUserIdAsync(string userId)
        {
            var postComments = await _postCommentRepository.GetAllFilteredAsync(p => p.UserId == userId);
            var postCommentResultDTOs = _mapper.Map<ICollection<PostCommentResultDTO>>(postComments);

            return postCommentResultDTOs;
        }

        public async Task<ICollection<PostCommentResultDTO>> GetAllByPostIdAsync(string postId)
        {
            var postComments = await _postCommentRepository.GetAllFilteredAsync(p => p.PostId == postId);
            var postCommentsResultDTOs = _mapper.Map<ICollection<PostCommentResultDTO>>(postComments);

            return postCommentsResultDTOs;
        }

        public async Task<ICollection<PostCommentResultDTO>> GetAllByIdAsync(string postCommentId)
        {
            var postComments = await _postCommentRepository.GetAllFilteredAsync(p => p.PostCommentId == postCommentId);
            var postCommentsResultDTOs = _mapper.Map<ICollection<PostCommentResultDTO>>(postComments);

            return postCommentsResultDTOs;
        }

        public async Task<IResult<PostCommentResultDTO>> AddAsync(PostCommentAddDTO postCommentAddDTO)
        {
            var existingUser = await _userManager.FindByIdAsync(postCommentAddDTO.UserId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostCommentResultDTO>(InstaConnectErrorMessages.UserNotFound);

                return badRequestResult;
            }

            var existingPost = await _postRepository.FindEntityAsync(p => p.Id == postCommentAddDTO.PostId);

            if (existingPost == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostCommentResultDTO>(InstaConnectErrorMessages.PostNotFound);

                return badRequestResult;
            }

            var existingPostComment = await _postCommentRepository.FindEntityAsync(c => c.Id == postCommentAddDTO.PostCommentId);

            if (postCommentAddDTO.PostCommentId != null && existingPostComment == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostCommentResultDTO>(InstaConnectErrorMessages.PostCommentNotFound);

                return badRequestResult;
            }

            var postComment = _mapper.Map<PostComment>(postCommentAddDTO);
            await _postCommentRepository.AddAsync(postComment);

            var noContentResult = _resultFactory.GetNoContentResult<PostCommentResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostCommentResultDTO>> UpdateAsync(string id, PostCommentUpdateDTO postCommentUpdateDTO)
        {
            var postComment = await _postCommentRepository.FindEntityAsync(c => c.Id == id);

            if (postComment == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostCommentResultDTO>(InstaConnectErrorMessages.PostCommentNotFound);

                return notFoundResult;
            }

            _mapper.Map(postCommentUpdateDTO, postComment);
            await _postCommentRepository.UpdateAsync(postComment);

            var noContentResult = _resultFactory.GetNoContentResult<PostCommentResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostCommentResultDTO>> DeleteAsync(string id)
        {
            var postComment = await _postCommentRepository.FindEntityAsync(c => c.Id == id);

            if (postComment == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostCommentResultDTO>(InstaConnectErrorMessages.PostCommentNotFound);

                return notFoundResult;
            }

            await _postCommentRepository.DeleteAsync(postComment);

            var noContentResult = _resultFactory.GetNoContentResult<PostCommentResultDTO>();

            return noContentResult;
        }
    }
}
