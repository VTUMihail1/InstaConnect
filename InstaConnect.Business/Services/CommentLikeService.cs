using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Business.Services
{
    public class CommentLikeService : ICommentLikeService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly ICommentLikeRepository _commentLikeRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<User> _userManager;

        public CommentLikeService(
            IMapper mapper,
            IResultFactory resultFactory,
            ICommentLikeRepository commentLikeRepository,
            ICommentRepository commentRepository,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _commentLikeRepository = commentLikeRepository;
            _commentRepository = commentRepository;
            _userManager = userManager;
        }

        public async Task<ICollection<CommentLikeResultDTO>> GetAllByUserIdAsync(string userId)
        {
            var commentLikes = await _commentLikeRepository.GetAllFilteredAsync(c => c.UserId == userId);
            var commentLikeResultDTOs = _mapper.Map<ICollection<CommentLikeResultDTO>>(commentLikes);

            return commentLikeResultDTOs;
        }

        public async Task<ICollection<CommentLikeResultDTO>> GetAllByCommentIdAsync(string commentId)
        {
            var commentLikes = await _commentLikeRepository.GetAllFilteredAsync(c => c.CommentId == commentId);
            var commentLikeResultDTOs = _mapper.Map<ICollection<CommentLikeResultDTO>>(commentLikes);

            return commentLikeResultDTOs;
        }

        public async Task<IResult<CommentLikeResultDTO>> AddAsync(CommentLikeAddDTO commentLikeAddDTO)
        {
            var existingUser = await _userManager.FindByIdAsync(commentLikeAddDTO.UserId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<CommentLikeResultDTO>();

                return badRequestResult;
            }

            var existingComment = await _commentRepository.FindEntityAsync(c => c.Id == commentLikeAddDTO.CommentId);

            if (existingComment == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<CommentLikeResultDTO>();

                return badRequestResult;
            }

            var existingCommentLike = await _commentLikeRepository.FindEntityAsync(l => l.UserId == commentLikeAddDTO.UserId && l.CommentId == commentLikeAddDTO.CommentId);

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

        public async Task<IResult<CommentLikeResultDTO>> DeleteAsync(string userId, string commentId)
        {
            var commentLike = await _commentLikeRepository.FindEntityAsync(l => l.UserId == userId && l.CommentId == commentId);

            if (commentLike == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<CommentLikeResultDTO>(InstaConnectErrorMessages.LikeNotFound);

                return notFoundResult;
            }

            await _commentLikeRepository.DeleteAsync(commentLike);

            var noContentResult = _resultFactory.GetNoContentResult<CommentLikeResultDTO>();

            return noContentResult;
        }
    }
}
