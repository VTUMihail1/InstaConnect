using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.Services
{
    public class PostCommentService : IPostCommentService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostCommentService(
            IMapper mapper,
            IResultFactory resultFactory,
            IPostCommentRepository postCommentRepository,
            IPostRepository postRepository,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _postCommentRepository = postCommentRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<IResult<ICollection<PostCommentResultDTO>>> GetAllAsync(
            string userId,
            string postId,
            string postCommentId,
            int page,
            int amount)
        {
            var skipAmount = (page - 1) * amount;

            var postComments = await _postCommentRepository.GetAllAsync(pc =>
            (userId == default || pc.UserId == userId) &&
            (postId == default || pc.PostId == postId) &&
            (postCommentId == default || pc.PostCommentId == postCommentId),
            skipAmount,
            amount);

            var postCommentsResultDTOs = _mapper.Map<ICollection<PostCommentResultDTO>>(postComments);
            var okResult = _resultFactory.GetOkResult(postCommentsResultDTOs);

            return okResult;
        }

        public async Task<IResult<PostCommentResultDTO>> GetByIdAsync(string id)
        {
            var existingPostComment = await _postCommentRepository.FindEntityAsync(pc => pc.Id == id);

            if (existingPostComment == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostCommentResultDTO>();

                return notFoundResult;
            }

            var postCommentResultDTO = _mapper.Map<PostCommentResultDTO>(existingPostComment);
            var okResult = _resultFactory.GetOkResult(postCommentResultDTO);

            return okResult;
        }

        public async Task<IResult<PostCommentResultDTO>> AddAsync(PostCommentAddDTO postCommentAddDTO)
        {
            var existingUser = await _userRepository.FindEntityAsync(f => f.Id == postCommentAddDTO.UserId);

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

            var existingPostComment = await _postCommentRepository.FindEntityAsync(pc => pc.Id == postCommentAddDTO.PostCommentId);

            if (postCommentAddDTO.PostCommentId != null && existingPostComment == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostCommentResultDTO>(InstaConnectErrorMessages.CommentNotFound);

                return badRequestResult;
            }

            var postComment = _mapper.Map<PostComment>(postCommentAddDTO);
            await _postCommentRepository.AddAsync(postComment);

            var noContentResult = _resultFactory.GetNoContentResult<PostCommentResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostCommentResultDTO>> UpdateAsync(string userId, string id, PostCommentUpdateDTO postCommentUpdateDTO)
        {
            var existingPostComment = await _postCommentRepository.FindEntityAsync(pc => pc.Id == id && pc.UserId == userId);

            if (existingPostComment == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostCommentResultDTO>();

                return notFoundResult;
            }

            _mapper.Map(postCommentUpdateDTO, existingPostComment);
            await _postCommentRepository.UpdateAsync(existingPostComment);

            var noContentResult = _resultFactory.GetNoContentResult<PostCommentResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostCommentResultDTO>> DeleteAsync(string userId, string id)
        {
            var existingPostComment = await _postCommentRepository.FindEntityAsync(pc => pc.Id == id && pc.UserId == userId);

            if (existingPostComment == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostCommentResultDTO>();

                return notFoundResult;
            }

            await _postCommentRepository.DeleteAsync(existingPostComment);

            var noContentResult = _resultFactory.GetNoContentResult<PostCommentResultDTO>();

            return noContentResult;
        }
    }
}
