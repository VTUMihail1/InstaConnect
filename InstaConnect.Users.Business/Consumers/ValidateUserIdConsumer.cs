using AutoMapper;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Data.Abstraction.Repositories;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Users.Business.Consumers
{
    public class ValidateUserIdConsumer : IConsumer<ValidateUserIdRequest>
    {
        private readonly IUserRepository _userRepository;

        public ValidateUserIdConsumer(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Consume(ConsumeContext<ValidateUserIdRequest> context)
        {
            var existingUser = await _userRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

            if(existingUser == null)
            {
                throw new UserNotFoundException();
            }
        }
    }
}
