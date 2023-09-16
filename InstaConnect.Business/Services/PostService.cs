using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IPostRepository _postRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly ICommentRepository _commentRepository;

        public PostService(
            IMapper mapper, 
            IResultFactory resultFactory, 
            IPostRepository postRepository, 
            ILikeRepository likeRepository, 
            ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _postRepository = postRepository;
            _likeRepository = likeRepository;
            _commentRepository = commentRepository;
        }

        public async Task<ICollection<PostResultDTO>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            var postResultDTOs = _mapper.Map<ICollection<PostResultDTO>>(posts);

            return postResultDTOs;
        }

        public async Task<ICollection<PostResultDTO>> GetAllByUserId(string userId)
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


        public async Task<IResult<PostResultDTO>> AddPostLikeAsync(PostAddLikeDTO postAddLikeDTO)
        {
            var existingLike = await _likeRepository.FindEntityAsync(l => l.UserId == postAddLikeDTO.UserId && l.PostId == postAddLikeDTO.PostId);

            if (existingLike != null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostResultDTO>();

                return badRequestResult;
            }

            var like = _mapper.Map<Like>(postAddLikeDTO);
            await _likeRepository.AddAsync(like);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostResultDTO>> DeletePostLikeAsync(string userId, string postId)
        {
            var existingLike = await _likeRepository.FindEntityAsync(l => l.UserId == userId && l.PostId == postId);

            if (existingLike == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostResultDTO>();

                return badRequestResult;
            }

            await _likeRepository.DeleteAsync(existingLike);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostResultDTO>> AddPostCommentAsync(PostAddCommentDTO postAddCommentDTO)
        {
            var comment = _mapper.Map<Comment>(postAddCommentDTO);
            await _commentRepository.DeleteAsync(comment);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostResultDTO>> UpdatePostCommentAsync(string commentId, PostUpdateCommentDTO postUpdateCommentDTO)
        {
            var comment = await _commentRepository.FindEntityAsync(c => c.Id == commentId);

            if (comment == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostResultDTO>();

                return badRequestResult;
            }

            _mapper.Map(postUpdateCommentDTO, comment);
            await _commentRepository.UpdateAsync(comment);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<PostResultDTO>> DeletePostCommentAsync(string commentId)
        {
            var comment = await _commentRepository.FindEntityAsync(c => c.Id == commentId);

            if (comment == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<PostResultDTO>();

                return badRequestResult;
            }

            await _commentRepository.DeleteAsync(comment);

            var noContentResult = _resultFactory.GetNoContentResult<PostResultDTO>();

            return noContentResult;
        }
    }
}
