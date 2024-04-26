using AutoMapper;
using InstaConnect.Messages.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Messages.Business.Commands.PostComments.DeletePostComment;
using InstaConnect.Messages.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Messages.Business.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Messages.Business.Queries.PostComments.GetAllPostComments;
using InstaConnect.Messages.Business.Queries.PostComments.GetPostCommentById;
using InstaConnect.Messages.Web.Models.Requests.PostComment;
using InstaConnect.Messages.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Controllers
{
    [ApiController]
    [Route("api/messages")]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public MessageController(
            IMapper mapper,
            ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        // GET: api/messages
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync(CollectionRequestModel collectionRequestModel)
        {
            var getAllMessagesQuery = _mapper.Map<GetAllMessagesQuery>(collectionRequestModel);
            var response = await _sender.Send(getAllMessagesQuery);
            var messageViewModels = _mapper.Map<ICollection<MessageViewModel>>(response);

            return Ok(messageViewModels);
        }

        // GET: api/messages/filtered
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllFilteredAsync(GetMessageCollectionRequestModel getMessageCollectionRequestModel)
        {
            var getAllFilteredMessagesQuery = _mapper.Map<GetAllFilteredMessagesQuery>(getMessageCollectionRequestModel);
            var response = await _sender.Send(getAllFilteredMessagesQuery);
            var messageViewModels = _mapper.Map<ICollection<MessageViewModel>>(response);

            return Ok(messageViewModels);
        }

        // GET: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(GetMessageByIdRequestModel getMessageByIdRequestModel)
        {
            var getMessageByIdQuery = _mapper.Map<GetMessageByIdQuery>(getMessageByIdRequestModel);
            var response = await _sender.Send(getMessageByIdQuery);
            var messageViewModel = _mapper.Map<MessageViewModel>(response);

            return Ok(messageViewModel);
        }

        // POST: api/messages
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddAsync(AddMessageRequestModel addMessageRequestModel)
        {
            var addMessageCommand = _mapper.Map<AddMessageCommand>(addMessageRequestModel);
            await _sender.Send(addMessageCommand);

            return NoContent();
        }

        // PUT: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpPut("{id}/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(UpdateMessageRequestModel updateMessageRequestModel)
        {
            var updateMessageCommand = _mapper.Map<UpdateMessageCommand>(updateMessageRequestModel);
            await _sender.Send(updateMessageCommand);

            return NoContent();
        }

        //DELETE: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpDelete("{id}/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByUserAsync(DeleteMessageRequestModel deleteMessageRequestModel)
        {
            var deleteMessageCommand = _mapper.Map<DeleteMessageCommand>(deleteMessageRequestModel);
            await _sender.Send(deleteMessageCommand);

            return NoContent();
        }
    }
}

