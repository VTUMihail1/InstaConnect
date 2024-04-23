using AutoMapper;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Response;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Users.Data.Abstraction.Repositories;
using MassTransit;

namespace InstaConnect.Users.Business.Consumers
{
    public class GetUserByIdConsumer : IConsumer<GetUserByIdRequest>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByIdConsumer(
            IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task Consume(ConsumeContext<GetUserByIdRequest> context)
        {
            var user = await _userRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);
            var doesUserExist = user == null;

            var userResponse = _mapper.Map<GetUserByIdResponse>(doesUserExist);

            await context.RespondAsync(userResponse);
        }
    }
}
