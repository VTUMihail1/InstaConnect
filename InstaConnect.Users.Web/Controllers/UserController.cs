using AutoMapper;
using InstaConnect.Shared.Data.Utilities;
using InstaConnect.Shared.Web.Models.Filters;
using InstaConnect.Users.Business.Queries.GetAllFilteredUsers;
using InstaConnect.Users.Business.Queries.GetAllUsers;
using InstaConnect.Users.Business.Queries.GetDetailedUserById;
using InstaConnect.Users.Business.Queries.GetUserById;
using InstaConnect.Users.Business.Queries.GetUserByName;
using InstaConnect.Users.Web.Extensions;
using InstaConnect.Users.Web.Filters;
using InstaConnect.Users.Web.Models.Requests.User;
using InstaConnect.Users.Web.Models.Response.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public UserController(
            IMapper mapper,
            ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        // GET: api/users
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(
            CollectionRequestModel request,
            CancellationToken cancellationToken)
        {
            var getAllUsersQuery = _mapper.Map<GetAllUsersQuery>(request);

            var userViewDTOs = await _sender.Send(getAllUsersQuery, cancellationToken);

            var userResponseModels = _mapper.Map<ICollection<UserResponseModel>>(userViewDTOs);

            return Ok(userResponseModels);
        }

        // GET: api/users/filtered
        [HttpGet("filtered")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(
            GetUserCollectionRequestModel request,
            CancellationToken cancellationToken)
        {
            var getAllFilteredUsersQuery = _mapper.Map<GetAllFilteredUsersQuery>(request);

            var userViewDTOs = await _sender.Send(getAllFilteredUsersQuery, cancellationToken);

            var userResponseModels = _mapper.Map<ICollection<UserResponseModel>>(userViewDTOs);

            return Ok(userResponseModels);
        }

        // GET: api/users/current/detailed
        [Authorize]
        [AccessToken]
        [HttpGet("current/detailed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonalAsync(CancellationToken cancellationToken)
        {
            var userRequestModel = User.GetUserRequestModel;
            var getPersonalUserByIdQuery = _mapper.Map<GetDetailedUserByIdQuery>(userRequestModel);

            var userDetailedViewDTO = await _sender.Send(getPersonalUserByIdQuery, cancellationToken);
            var userDetailedResponseModel = _mapper.Map<UserDetailedResponseModel>(userDetailedViewDTO);

            return Ok(userDetailedResponseModel);
        }

        // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/detailed
        [Authorize]
        [AccessToken]
        [RequiredRole(Roles.Admin)]
        [HttpGet("{id}/detailed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonalByIdAsync(
            GetUserDetailedByIdRequestModel request,
            CancellationToken cancellationToken)
        {
            var getPersonalUserByIdQuery = _mapper.Map<GetDetailedUserByIdQuery>(request);

            var userDetailedViewDTO = await _sender.Send(getPersonalUserByIdQuery, cancellationToken);
            var userDetailedResponseModel = _mapper.Map<UserDetailedResponseModel>(userDetailedViewDTO);

            return Ok(userDetailedResponseModel);
        }

        // GET: api/users/current
        [HttpGet("current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var userRequestModel = User.GetUserRequestModel;
            var getUserByIdQuery = _mapper.Map<GetUserByIdQuery>(userRequestModel);

            var userViewDTO = await _sender.Send(getUserByIdQuery, cancellationToken);
            var userResponseModel = _mapper.Map<UserResponseModel>(userViewDTO);

            return Ok(userResponseModel);
        }

        // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(
            GetUserByIdRequestModel request,
            CancellationToken cancellationToken)
        {
            var getUserByIdQuery = _mapper.Map<GetUserByIdQuery>(request);

            var userViewDTO = await _sender.Send(getUserByIdQuery, cancellationToken);
            var userResponseModel = _mapper.Map<UserResponseModel>(userViewDTO);

            return Ok(userResponseModel);
        }

        // GET: api/users/by-username/example
        [HttpGet("by-username/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUsernameAsync(
            GetUserByUserNameRequestModel request,
            CancellationToken cancellationToken)
        {
            var getUserByNameQuery = _mapper.Map<GetUserByNameQuery>(request);

            var userViewDTO = await _sender.Send(getUserByNameQuery, cancellationToken);
            var userResponseModel = _mapper.Map<UserResponseModel>(userViewDTO);

            return Ok(userResponseModel);
        }
    }
}
