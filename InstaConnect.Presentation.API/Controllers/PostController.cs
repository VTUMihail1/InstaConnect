﻿using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Presentation.API.Extensions;
using InstaConnect.Presentation.API.Filters;
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
        public async Task<IActionResult> GetAllAsync([FromQuery] string userId = default)
        {
            var response = await _postService.GetAllAsync(userId);

            return Ok(response);
        }

        // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var response = await _postService.GetByIdAsync(id);

            return this.HandleResponse(response);
        }

        // POST: api/posts
        [Authorize]
        [AccessToken]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddAsync([FromBody] PostAddDTO postAddDTO)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postService.AddAsync(currentUserId, postAddDTO);

            return this.HandleResponse(response);
        }

        // PUT: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] PostUpdateDTO postUpdateDTO)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postService.UpdateAsync(currentUserId, id, postUpdateDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postService.DeleteAsync(currentUserId, id);

            return this.HandleResponse(response);
        }
    }
}
