using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Extensions;
using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Models.Utilities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Business.Services
{
    public class CommentLikeService : ICommentLikeService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly ICommentLikeRepository _commentLikeRepository;
        private readonly IPostCommentRepository _commentRepository;
        private readonly UserManager<User> _userManager;

        public CommentLikeService(
            IMapper mapper,
            IResultFactory resultFactory,
            ICommentLikeRepository commentLikeRepository,
            IPostCommentRepository commentRepository,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _commentLikeRepository = commentLikeRepository;
            _commentRepository = commentRepository;
            _userManager = userManager;
        }

        public async Task<ICollection<CommentLikeResultDTO>> GetAllAsync(string userId, string postCommentId)
        {
            var commentLikes = await _commentLikeRepository.GetAllAsync(cl =>
            (userId == default || cl.UserId == userId) &&
            (postCommentId == default || cl.PostCommentId == postCommentId));

            var commentLikeResultDTOs = _mapper.Map<ICollection<CommentLikeResultDTO>>(commentLikes);

            return commentLikeResultDTOs;
        }

        public async Task<IResult<CommentLikeResultDTO>> GetByIdAsync(string id)
        {
            var existingCommentLike = await _commentLikeRepository.FindEntityAsync(cl => cl.Id == id);

            if (existingCommentLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<CommentLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

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
                var notFoundResult = _resultFactory.GetNotFoundResult<CommentLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }

            var commentLikeResultDTO = _mapper.Map<CommentLikeResultDTO>(existingCommentLike);
            var okResult = _resultFactory.GetOkResult(commentLikeResultDTO);

            return okResult;
        }

        public async Task<IResult<CommentLikeResultDTO>> AddAsync(string currentUserId, CommentLikeAddDTO commentLikeAddDTO)
        {
            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUserId, commentLikeAddDTO.UserId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<CommentLikeResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
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

        public async Task<IResult<CommentLikeResultDTO>> DeleteByPostCommentIdAndUserIdAsync(string currentUserId, string userId, string postCommentId)
        {
            var existingCommentLike = await _commentLikeRepository.FindEntityAsync(cl => cl.UserId == userId && cl.PostCommentId == postCommentId);

            if (existingCommentLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<CommentLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }

            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUserId, userId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<CommentLikeResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            await _commentLikeRepository.DeleteAsync(existingCommentLike);

            var noContentResult = _resultFactory.GetNoContentResult<CommentLikeResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<CommentLikeResultDTO>> DeleteAsync(string currentUserId, string id)
        {
            var existingCommentLike = await _commentLikeRepository.FindEntityAsync(cl => cl.Id == id);

            if (existingCommentLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<CommentLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }

            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUserId, existingCommentLike.UserId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<CommentLikeResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            await _commentLikeRepository.DeleteAsync(existingCommentLike);

            var noContentResult = _resultFactory.GetNoContentResult<CommentLikeResultDTO>();

            return noContentResult;
        }

    }
}
