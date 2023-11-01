using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.PostCommentLike;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.Services
{
    public class PostCommentLikeService : IPostCommentLikeService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IPostCommentLikeRepository _postCommentLikeRepository;
        private readonly IPostCommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;

        public PostCommentLikeService(
            IMapper mapper,
            IResultFactory resultFactory,
            IPostCommentLikeRepository postCommentLikeRepository,
            IPostCommentRepository commentRepository,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _postCommentLikeRepository = postCommentLikeRepository;
            _commentRepository = commentRepository; ;
            _userRepository = userRepository;
        }

        public async Task<IResult<ICollection<PostCommentLikeResultDTO>>> GetAllAsync(
            string userId,
            string postCommentId,
            int page,
            int amount)
        {
            var skipAmount = (page - 1) * amount;

            var postCommentLikes = await _postCommentLikeRepository.GetAllAsync(cl =>
            (userId == default || cl.UserId == userId) &&
            (postCommentId == default || cl.PostCommentId == postCommentId), skipAmount, amount);

            var postCommentLikeResultDTOs = _mapper.Map<ICollection<PostCommentLikeResultDTO>>(postCommentLikes);
            var okResult = _resultFactory.GetOkResult(postCommentLikeResultDTOs);

            return okResult;
        }

        public async Task<IResult<PostCommentLikeResultDTO>> GetByIdAsync(string id)
        {
            var existingPostCommentLike = await _postCommentLikeRepository.FindEntityAsync(cl => cl.Id == id);

            if (existingPostCommentLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostCommentLikeResultDTO>();

                return notFoundResult;
            }

            var postCommentLikeResultDTO = _mapper.Map<PostCommentLikeResultDTO>(existingPostCommentLike);
            var okResult = _resultFactory.GetOkResult(postCommentLikeResultDTO);

            return okResult;
        }

        public async Task<IResult<PostCommentLikeResultDTO>> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId)
        {
            var existingPostCommentLike = await _postCommentLikeRepository.FindEntityAsync(cl => cl.UserId == userId && cl.PostCommentId == postCommentId);

            if (existingPostCommentLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostCommentLikeResultDTO>();

                return notFoundResult;
            }

            var postCommentLikeResultDTO = _mapper.Map<PostCommentLikeResultDTO>(existingPostCommentLike);
            var okResult = _resultFactory.GetOkResult(postCommentLikeResultDTO);

            return okResult;
        }

        public async Task<IResult<PostCommentLikeResultDTO>> AddAsync(PostCommentLikeAddDTO postCommentLikeAddDTO)
        {
            var existingUser = await _userRepository.FindEntityAsync(f => f.Id == postCommentLikeAddDTO.UserId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostCommentLikeResultDTO>(InstaConnectErrorMessages.UserNotFound);

                return badRequestResult;
            }

            var existingComment = await _commentRepository.FindEntityAsync(c => c.Id == postCommentLikeAddDTO.PostCommentId);

            if (existingComment == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostCommentLikeResultDTO>(InstaConnectErrorMessages.LikeAlreadyExists);

                return badRequestResult;
            }

            var existingPostCommentLike = await _postCommentLikeRepository.FindEntityAsync(cl => cl.UserId == postCommentLikeAddDTO.UserId && cl.PostCommentId == postCommentLikeAddDTO.PostCommentId);

            if (existingPostCommentLike != null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostCommentLikeResultDTO>(InstaConnectErrorMessages.LikeAlreadyExists);

                return badRequestResult;
            }

            var postCommentLike = _mapper.Map<PostCommentLike>(postCommentLikeAddDTO);
            await _postCommentLikeRepository.AddAsync(postCommentLike);

            var noContentResult = _resultFactory.GetNoContentResult<PostCommentLikeResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostCommentLikeResultDTO>> DeleteByUserIdAndPostCommentIdAsync(string userId, string postCommentId)
        {
            var existingPostCommentLike = await _postCommentLikeRepository.FindEntityAsync(cl => cl.UserId == userId && cl.PostCommentId == postCommentId);

            if (existingPostCommentLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostCommentLikeResultDTO>();

                return notFoundResult;
            }

            await _postCommentLikeRepository.DeleteAsync(existingPostCommentLike);

            var noContentResult = _resultFactory.GetNoContentResult<PostCommentLikeResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostCommentLikeResultDTO>> DeleteAsync(string userId, string id)
        {
            var existingPostCommentLike = await _postCommentLikeRepository.FindEntityAsync(cl => cl.Id == id && cl.UserId == userId);

            if (existingPostCommentLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostCommentLikeResultDTO>();

                return notFoundResult;
            }

            await _postCommentLikeRepository.DeleteAsync(existingPostCommentLike);

            var noContentResult = _resultFactory.GetNoContentResult<PostCommentLikeResultDTO>();

            return noContentResult;
        }
    }
}
