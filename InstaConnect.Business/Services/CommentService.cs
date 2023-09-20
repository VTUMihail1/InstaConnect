using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Comment;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Business.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly UserManager<User> _userManager;

        public CommentService(
            IMapper mapper,
            IResultFactory resultFactory,
            ICommentRepository commentRepository,
            IPostRepository postRepository,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _userManager = userManager;
        }

        public async Task<ICollection<CommentResultDTO>> GetAllByUserIdAsync(string userId)
        {
            var comments = await _commentRepository.GetAllFilteredAsync(p => p.UserId == userId);
            var commentResultDTOs = _mapper.Map<ICollection<CommentResultDTO>>(comments);

            return commentResultDTOs;
        }

        public async Task<ICollection<CommentResultDTO>> GetAllByPostIdAsync(string postId)
        {
            var comments = await _commentRepository.GetAllFilteredAsync(p => p.PostId == postId);
            var commentResultDTOs = _mapper.Map<ICollection<CommentResultDTO>>(comments);

            return commentResultDTOs;
        }

        public async Task<ICollection<CommentResultDTO>> GetAllByIdAsync(string commentId)
        {
            var comments = await _commentRepository.GetAllFilteredAsync(p => p.CommentId == commentId);
            var commentResultDTOs = _mapper.Map<ICollection<CommentResultDTO>>(comments);

            return commentResultDTOs;
        }

        public async Task<IResult<CommentResultDTO>> AddAsync(CommentAddDTO commentAddDTO)
        {
            var existingUser = await _userManager.FindByIdAsync(commentAddDTO.UserId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<CommentResultDTO>(InstaConnectErrorMessages.UserNotFound);

                return badRequestResult;
            }

            var existingPost = await _postRepository.FindEntityAsync(p => p.Id == commentAddDTO.PostId);

            if (existingPost == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<CommentResultDTO>(InstaConnectErrorMessages.PostNotFound);

                return badRequestResult;
            }

            var existingComment = await _commentRepository.FindEntityAsync(c => c.Id == commentAddDTO.CommentId);

            if (commentAddDTO.CommentId != null && existingComment == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<CommentResultDTO>(InstaConnectErrorMessages.CommentNotFound);

                return badRequestResult;
            }

            var comment = _mapper.Map<Comment>(commentAddDTO);
            await _commentRepository.AddAsync(comment);

            var noContentResult = _resultFactory.GetNoContentResult<CommentResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<CommentResultDTO>> UpdateAsync(string id, CommentUpdateDTO commentUpdateDTO)
        {
            var comment = await _commentRepository.FindEntityAsync(c => c.Id == id);

            if (comment == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<CommentResultDTO>(InstaConnectErrorMessages.CommentNotFound);

                return notFoundResult;
            }

            _mapper.Map(commentUpdateDTO, comment);
            await _commentRepository.UpdateAsync(comment);

            var noContentResult = _resultFactory.GetNoContentResult<CommentResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<CommentResultDTO>> DeleteAsync(string id)
        {
            var comment = await _commentRepository.FindEntityAsync(c => c.Id == id);

            if (comment == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<CommentResultDTO>(InstaConnectErrorMessages.CommentNotFound);

                return notFoundResult;
            }

            await _commentRepository.DeleteAsync(comment);

            var noContentResult = _resultFactory.GetNoContentResult<CommentResultDTO>();

            return noContentResult;
        }
    }
}
