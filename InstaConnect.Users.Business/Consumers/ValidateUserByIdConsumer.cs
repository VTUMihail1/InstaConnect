using AutoMapper;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Users.Data.Abstraction.Helpers;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Users.Business.Consumers
{
    public class ValidateUserByIdConsumer : IConsumer<ValidateUserByIdRequest>
    {
        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;

        public ValidateUserByIdConsumer(
            IMapper mapper, 
            IAccountManager accountManager)
        {
            _mapper = mapper;
            _accountManager = accountManager;
        }

        public async Task Consume(ConsumeContext<ValidateUserByIdRequest> context)
        {
            var isValidUser = _accountManager.ValidateUser(context.Message.CurrentUserId, context.Message.Id);

            var validateUserByIdResponse = _mapper.Map<ValidateUserByIdResponse>(isValidUser);

            await context.RespondAsync(validateUserByIdResponse);
        }
    }
}
