using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostComments.AddPost;
using InstaConnect.Posts.Business.Commands.PostComments.DeletePost;
using InstaConnect.Posts.Business.Commands.PostComments.UpdatePost;
using InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetPostById;
using InstaConnect.Posts.Web.Models.Requests.Post;
using InstaConnect.Posts.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Controllers
{
    [ApiController]
    [Route("api/post-comments")]
    public class PostCommentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public PostCommentController(
            IMapper mapper,
            ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        // GET: api/post-comments
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync(CollectionRequestModel collectionRequestModel)
        {
            var getAllPostCommentsQuery = _mapper.Map<GetAllPostCommentsQuery>(collectionRequestModel);
            var response = await _sender.Send(getAllPostCommentsQuery);
            var postCommentViewModels = _mapper.Map<ICollection<PostCommentViewModel>>(response);

            return Ok(postCommentViewModels);
        }

        // GET: api/post-comments/filtered
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllFilteredAsync(GetPostCommentsCollectionRequestModel getPostCommentsCollectionRequestModel)
        {
            var getAllFilteredPostCommentsQuery = _mapper.Map<GetAllFilteredPostCommentsQuery>(getPostCommentsCollectionRequestModel);
            var response = await _sender.Send(getAllFilteredPostCommentsQuery);
            var postCommentViewModels = _mapper.Map<ICollection<PostCommentViewModel>>(response);

            return Ok(postCommentViewModels);
        }

        // GET: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(GetPostCommentByIdRequestModel getPostCommentByIdRequestModel)
        {
            var getPostCommentByIdQuery = _mapper.Map<GetPostCommentByIdQuery>(getPostCommentByIdRequestModel);
            var response = await _sender.Send(getPostCommentByIdQuery);
            var postCommentViewModel = _mapper.Map<PostCommentViewModel>(response);

            return Ok(postCommentViewModel);
        }

        // POST: api/post-comments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddAsync(AddPostCommentRequestModel addPostCommentRequestModel)
        {
            var addPostCommentCommand = _mapper.Map<AddPostCommentCommand>(addPostCommentRequestModel);
            await _sender.Send(addPostCommentCommand);

            return NoContent();
        }

        // PUT: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpPut("{id}/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(UpdatePostCommentRequestModel updatePostCommentRequestModel)
        {
            var updatePostCommentCommand = _mapper.Map<UpdatePostCommentCommand>(updatePostCommentRequestModel);
            await _sender.Send(updatePostCommentCommand);

            return NoContent();
        }

        //DELETE: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpDelete("{id}/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByUserAsync(DeletePostCommentRequestModel deletePostCommentRequestModel)
        {
            var deletePostCommentCommand = _mapper.Map<DeletePostCommentCommand>(deletePostCommentRequestModel);
            await _sender.Send(deletePostCommentCommand);

            return NoContent();
        }
    }
}

