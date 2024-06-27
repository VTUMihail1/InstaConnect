using AutoMapper;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using MassTransit;

namespace InstaConnect.Identity.Business.Consumers;
internal class GetUserByIdConsumer : IConsumer<GetUserByIdRequest>
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
        var existingUser = await _userRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingUser == null)
        {
            await context.RespondAsync(null!);
        }

        var getUserByIdResponse = _mapper.Map<GetUserByIdResponse>(existingUser);
        await context.RespondAsync(getUserByIdResponse);
    }
}
