﻿using AutoMapper;
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

        public async Task<ICollection<PostCommentDetailedDTO>> GetAllDetailedAsync()
        {
            var postComments = await _postCommentRepository.GetAllIncludedAsync();
            var postCommentsDetailedDTOs = _mapper.Map<ICollection<PostCommentDetailedDTO>>(postComments);

            return postCommentsDetailedDTOs;
        }

        public async Task<ICollection<PostCommentDetailedDTO>> GetAllDetailedByUserIdAsync(string userId)
        {
            var postComments = await _postCommentRepository.GetAllFilteredIncludedAsync(pc => pc.UserId == userId);
            var postCommentsDetailedDTOs = _mapper.Map<ICollection<PostCommentDetailedDTO>>(postComments);

            return postCommentsDetailedDTOs;
        }

        public async Task<ICollection<PostCommentDetailedDTO>> GetAllDetailedByPostIdAsync(string postId)
        {
            var postComments = await _postCommentRepository.GetAllFilteredIncludedAsync(pc => pc.PostId == postId);
            var postCommentsDetailedDTOs = _mapper.Map<ICollection<PostCommentDetailedDTO>>(postComments);

            return postCommentsDetailedDTOs;
        }

        public async Task<ICollection<PostCommentDetailedDTO>> GetAllDetailedByParentIdAsync(string postCommentId)
        {
            var postComments = await _postCommentRepository.GetAllFilteredIncludedAsync(pc => pc.PostCommentId == postCommentId);
            var postCommentsDetailedDTOs = _mapper.Map<ICollection<PostCommentDetailedDTO>>(postComments);

            return postCommentsDetailedDTOs;
        }

        public async Task<IResult<PostCommentDetailedDTO>> GetDetailedByIdAsync(string id)
        {
            var postComment = await _postCommentRepository.FindIncludedAsync(pc => pc.Id == id);

            if (postComment == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostCommentDetailedDTO>(InstaConnectErrorMessages.PostNotFound);

                return notFoundResult;
            }

            var postCommentDetailedDTO = _mapper.Map<PostCommentDetailedDTO>(postComment);
            var okResult = _resultFactory.GetOkResult(postCommentDetailedDTO);

            return okResult;
        }

        public async Task<ICollection<PostCommentResultDTO>> GetAllAsync()
        {
            var postComments = await _postCommentRepository.GetAllAsync();
            var postCommentsResultDTOs = _mapper.Map<ICollection<PostCommentResultDTO>>(postComments);

            return postCommentsResultDTOs;
        }

        public async Task<ICollection<PostCommentResultDTO>> GetAllByUserIdAsync(string userId)
        {
            var postComments = await _postCommentRepository.GetAllFilteredAsync(pc => pc.UserId == userId);
            var postCommentResultDTOs = _mapper.Map<ICollection<PostCommentResultDTO>>(postComments);

            return postCommentResultDTOs;
        }

        public async Task<ICollection<PostCommentResultDTO>> GetAllByPostIdAsync(string postId)
        {
            var postComments = await _postCommentRepository.GetAllFilteredAsync(pc => pc.PostId == postId);
            var postCommentsResultDTOs = _mapper.Map<ICollection<PostCommentResultDTO>>(postComments);

            return postCommentsResultDTOs;
        }

        public async Task<ICollection<PostCommentResultDTO>> GetAllByParentIdAsync(string postCommentId)
        {
            var postComments = await _postCommentRepository.GetAllFilteredAsync(pc => pc.PostCommentId == postCommentId);
            var postCommentsResultDTOs = _mapper.Map<ICollection<PostCommentResultDTO>>(postComments);

            return postCommentsResultDTOs;
        }

        public async Task<IResult<PostCommentResultDTO>> GetByIdAsync(string id)
        {
            var postComment = await _postCommentRepository.FindEntityAsync(pc => pc.Id == id);

            if (postComment == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<PostCommentResultDTO>(InstaConnectErrorMessages.PostNotFound);

                return notFoundResult;
            }

            var postCommentResultDTO = _mapper.Map<PostCommentResultDTO>(postComment);
            var okResult = _resultFactory.GetOkResult(postCommentResultDTO);

            return okResult;
        }

        public async Task<IResult<PostCommentResultDTO>> AddAsync(PostCommentAddDTO postCommentAddDTO)
        {
            var existingUser = await _userManager.FindByIdAsync(postCommentAddDTO.UserId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostCommentResultDTO>(InstaConnectErrorMessages.UserNotFound);

                return badRequestResult;
            }

            var existingPost = await _postRepository.FindEntityAsync(pc => pc.Id == postCommentAddDTO.PostId);

            if (existingPost == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostCommentResultDTO>(InstaConnectErrorMessages.PostNotFound);

                return badRequestResult;
            }

            var existingPostComment = await _postCommentRepository.FindEntityAsync(pc => pc.Id == postCommentAddDTO.PostCommentId);

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
            var postComment = await _postCommentRepository.FindEntityAsync(pc => pc.Id == id);

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
            var postComment = await _postCommentRepository.FindEntityAsync(pc => pc.Id == id);

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
