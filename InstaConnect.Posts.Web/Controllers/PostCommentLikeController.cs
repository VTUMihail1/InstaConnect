using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllPostCommentLikes;
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetPostCommentLikeById;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Web.Models.Requests.PostCommentLike;
using InstaConnect.Posts.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Controllers
{
    [ApiController]
    [Route("api/post-comment-likes")]
    public class PostCommentLikeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public PostCommentLikeController(
            IMapper mapper,
            ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        // GET: api/post-comment-likes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync(CollectionRequestModel collectionRequestModel)
        {
            var getAllPostCommentLikesQuery = _mapper.Map<GetAllPostCommentLikesQuery>(collectionRequestModel);
            var response = await _sender.Send(getAllPostCommentLikesQuery);
            var postCommentLikeViewModels = _mapper.Map<ICollection<PostCommentLikeViewModel>>(response);

            return Ok(postCommentLikeViewModels);
        }

        // GET: api/post-comment-likes/filtered
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllFilteredAsync(GetPostCommentLikesCollectionRequestModel getPostCommentLikesCollectionRequestModel)
        {
            var getAllFilteredPostCommentLikesQuery = _mapper.Map<GetAllFilteredPostCommentLikesQuery>(getPostCommentLikesCollectionRequestModel);
            var response = await _sender.Send(getAllFilteredPostCommentLikesQuery);
            var postCommentLikeViewModels = _mapper.Map<ICollection<PostLikeViewModel>>(response);

            return Ok(postCommentLikeViewModels);
        }

        // GET: api/post-comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(GetPostCommentLikeByIdRequestModel getPostCommentLikeByIdRequestModel)
        {
            var getPostCommentLikeByIdQuery = _mapper.Map<GetPostCommentLikeByIdQuery>(getPostCommentLikeByIdRequestModel);
            var response = await _sender.Send(getPostCommentLikeByIdQuery);
            var postCommentLikeViewModel = _mapper.Map<PostCommentLikeViewModel>(response);

            return Ok(postCommentLikeViewModel);
        }

        // POST: api/post-comment-likes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddAsync(AddPostCommentLikeRequestModel addPostCommentLikeRequestModel)
        {
            var addPostCommentLikeCommand = _mapper.Map<AddPostCommentLikeCommand>(addPostCommentLikeRequestModel);
            await _sender.Send(addPostCommentLikeCommand);

            return NoContent();
        }

        //DELETE: api/posts-comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpDelete("{id}/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByUserAsync(DeletePostCommentLikeRequestModel deletePostCommentLikeRequestModel)
        {
            var deletePostCommentLikeCommand = _mapper.Map<DeletePostCommentLikeCommand>(deletePostCommentLikeRequestModel);
            await _sender.Send(deletePostCommentLikeCommand);

            return NoContent();
        }
    }
}
