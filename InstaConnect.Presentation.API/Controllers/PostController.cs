using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Presentation.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Presentation.API.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/posts
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllAsync();

            return Ok(posts);
        }

        // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes
        [HttpGet("{id}/likes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPostLikes([FromRoute] string id)
        {
            var posts = await _postService.GetAllPostLikesAsync(id);

            return Ok(posts);
        }

        // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments
        [HttpGet("{id}/comments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPostComments([FromRoute] string id)
        {
            var posts = await _postService.GetAllPostCommentsAsync(id);

            return Ok(posts);
        }

        // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var response = await _postService.GetByIdAsync(id);

            return this.HandleResponse(response);
        }

        // GET: api/posts/user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByUserId([FromRoute] string userId)
        {
            var posts = await _postService.GetAllByUserId(userId);

            return Ok(posts);
        }

        // POST: api/posts
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddPost([FromBody] PostAddDTO postAddDTO)
        {
            var response = await _postService.AddAsync(postAddDTO);

            return this.HandleResponse(response);
        }

        // POST: api/posts/like
        [Authorize]
        [HttpPost("like")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPostLike([FromBody] PostAddLikeDTO postAddLikeDTO)
        {
            var response = await _postService.AddPostLikeAsync(postAddLikeDTO);

            return this.HandleResponse(response);
        }


        // POST: api/posts/comment
        [Authorize]
        [HttpPost("comment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPostComment([FromBody] PostAddCommentDTO postAddCommentDTO)
        {
            var response = await _postService.AddPostCommentAsync(postAddCommentDTO);

            return this.HandleResponse(response);
        }

        // PUT: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePost([FromRoute] string id, [FromBody] PostUpdateDTO postUpdateDTO)
        {
            var response = await _postService.UpdateAsync(id, postUpdateDTO);

            return this.HandleResponse(response);
        }

        // PUT: api/posts/comment/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpPut("comment/{commentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePostComment([FromRoute] string commentId, [FromBody] PostUpdateCommentDTO postUpdateCommentDTO)
        {
            var response = await _postService.UpdatePostCommentAsync(commentId, postUpdateCommentDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePost([FromRoute] string id)
        {
            var response = await _postService.DeleteAsync(id);

            return this.HandleResponse(response);
        }

        // DELETE: api/posts/like/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("like/{userId}/{postId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePostLike([FromRoute] string userId, [FromRoute] string postId)
        {
            var response = await _postService.DeletePostLikeAsync(userId, postId);

            return this.HandleResponse(response);
        }

        // DELETE: api/posts/comment/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("comment/{commentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePostComment([FromRoute] string commentId)
        {
            var response = await _postService.DeletePostCommentAsync(commentId);

            return this.HandleResponse(response);
        }
    }
}
