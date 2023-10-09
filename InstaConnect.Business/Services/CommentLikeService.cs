using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.Services
{
    public class CommentLikeService : ICommentLikeService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly ICommentLikeRepository _commentLikeRepository;
        private readonly IPostCommentRepository _commentRepository;
        private readonly IInstaConnectUserManager _instaConnectUserManager;

        public CommentLikeService(
            IMapper mapper,
            IResultFactory resultFactory,
            ICommentLikeRepository commentLikeRepository,
            IPostCommentRepository commentRepository,
            IInstaConnectUserManager instaConnectUserManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _commentLikeRepository = commentLikeRepository;
            _commentRepository = commentRepository;
            _instaConnectUserManager = instaConnectUserManager;
        }

        public async Task<IResult<ICollection<CommentLikeResultDTO>>> GetAllAsync(
            string userId,
            string postCommentId,
            int page,
            int amount)
        {
            var skipAmount = (page - 1) * amount;

            var commentLikes = await _commentLikeRepository.GetAllAsync(cl =>
            (userId == default || cl.UserId == userId) &&
            (postCommentId == default || cl.PostCommentId == postCommentId), skipAmount, amount);

            var commentLikeResultDTOs = _mapper.Map<ICollection<CommentLikeResultDTO>>(commentLikes);
            var okResult = _resultFactory.GetOkResult(commentLikeResultDTOs);

            return okResult;
        }

        public async Task<IResult<CommentLikeResultDTO>> GetByIdAsync(string id)
        {
            var existingCommentLike = await _commentLikeRepository.FindEntityAsync(cl => cl.Id == id);

            if (existingCommentLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<CommentLikeResultDTO>();

                return notFoundResult;
            }

            var commentLikeResultDTO = _mapper.Map<CommentLikeResultDTO>(existingCommentLike);
            var okResult = _resultFactory.GetOkResult(commentLikeResultDTO);

            return okResult;
        }

        public async Task<IResult<CommentLikeResultDTO>> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId)
        {
            var existingCommentLike = await _commentLikeRepository.FindEntityAsync(cl => cl.UserId == userId && cl.PostCommentId == postCommentId);

            if (existingCommentLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<CommentLikeResultDTO>();

                return notFoundResult;
            }

            var commentLikeResultDTO = _mapper.Map<CommentLikeResultDTO>(existingCommentLike);
            var okResult = _resultFactory.GetOkResult(commentLikeResultDTO);

            return okResult;
        }

        public async Task<IResult<CommentLikeResultDTO>> AddAsync(CommentLikeAddDTO commentLikeAddDTO)
        {
            var existingUser = _instaConnectUserManager.FindByIdAsync(commentLikeAddDTO.UserId);

            if (existingUser == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<CommentLikeResultDTO>();

                return notFoundResult;
            }

            var existingComment = await _commentRepository.FindEntityAsync(c => c.Id == commentLikeAddDTO.PostCommentId);

            if (existingComment == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<CommentLikeResultDTO>(InstaConnectErrorMessages.LikeAlreadyExists);

                return badRequestResult;
            }

            var existingCommentLike = await _commentLikeRepository.FindEntityAsync(cl => cl.UserId == commentLikeAddDTO.UserId && cl.PostCommentId == commentLikeAddDTO.PostCommentId);

            if (existingCommentLike != null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<CommentLikeResultDTO>(InstaConnectErrorMessages.LikeAlreadyExists);

                return badRequestResult;
            }

            var commentLike = _mapper.Map<CommentLike>(commentLikeAddDTO);
            await _commentLikeRepository.AddAsync(commentLike);

            var noContentResult = _resultFactory.GetNoContentResult<CommentLikeResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<CommentLikeResultDTO>> DeleteByUserIdAndPostCommentIdAsync(string userId, string postCommentId)
        {
            var existingCommentLike = await _commentLikeRepository.FindEntityAsync(cl => cl.UserId == userId && cl.PostCommentId == postCommentId);

            if (existingCommentLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<CommentLikeResultDTO>();

                return notFoundResult;
            }

            await _commentLikeRepository.DeleteAsync(existingCommentLike);

            var noContentResult = _resultFactory.GetNoContentResult<CommentLikeResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<CommentLikeResultDTO>> DeleteAsync(string userId, string id)
        {
            var existingCommentLike = await _commentLikeRepository.FindEntityAsync(cl => cl.Id == id && cl.UserId == userId);

            if (existingCommentLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<CommentLikeResultDTO>();

                return notFoundResult;
            }

            await _commentLikeRepository.DeleteAsync(existingCommentLike);

            var noContentResult = _resultFactory.GetNoContentResult<CommentLikeResultDTO>();

            return noContentResult;
        }
    }
}
