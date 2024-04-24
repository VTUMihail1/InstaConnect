﻿using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostComments.AddPost;
using InstaConnect.Posts.Business.Commands.PostComments.DeletePost;
using InstaConnect.Posts.Business.Commands.PostComments.UpdatePost;
using InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetPostById;
using InstaConnect.Posts.Web.Models.Requests.Post;
using InstaConnect.Posts.Web.Models.Responses;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Web.Models.Filters;
using InstaConnect.Users.Data.Models.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Posts.Web.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public PostController(
            IMapper mapper,
            ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        // GET: api/posts
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync(CollectionRequestModel collectionRequestModel)
        {
            var getAllPostsQuery = _mapper.Map<GetAllPostsQuery>(collectionRequestModel);
            var response = await _sender.Send(getAllPostsQuery);
            var postViewModels = _mapper.Map<ICollection<PostViewModel>>(response);

            return Ok(postViewModels);
        }

        // GET: api/posts/filtered
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllFilteredAsync(GetPostsCollectionRequestModel getPostsCollectionRequestModel)
        {
            var getAllFilteredPostsQuery = _mapper.Map<GetAllFilteredPostsQuery>(getPostsCollectionRequestModel);
            var response = await _sender.Send(getAllFilteredPostsQuery);
            var postViewModels = _mapper.Map<ICollection<PostViewModel>>(response);

            return Ok(postViewModels);
        }

        // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(GetPostByIdRequestModel getPostByIdRequestModel)
        {
            var getPostByIdQuery = _mapper.Map<GetPostByIdQuery>(getPostByIdRequestModel);
            var response = await _sender.Send(getPostByIdQuery);
            var postViewModel = _mapper.Map<PostViewModel>(response);

            return Ok(postViewModel);
        }

        // POST: api/posts
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddAsync(AddPostRequestModel addPostRequestModel)
        {
            var addPostCommand = _mapper.Map<AddPostCommand>(addPostRequestModel);
            await _sender.Send(addPostCommand);

            return NoContent();
        }

        // PUT: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpPut("{id}/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(UpdatePostRequestModel updatePostRequestModel)
        {
            var updatePostCommand = _mapper.Map<UpdatePostCommand>(updatePostRequestModel);
            await _sender.Send(updatePostCommand);

            return NoContent();
        }

        //DELETE: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpDelete("{id}/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByUserAsync(DeletePostRequestModel deletePostRequestModel)
        {
            var deletePostCommand = _mapper.Map<DeletePostCommand>(deletePostRequestModel);
            await _sender.Send(deletePostCommand);

            return NoContent();
        }
    }
}