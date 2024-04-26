using AutoMapper;
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
    public class GetCurrentUserDetailsConsumer : IConsumer<GetUserByIdRequest>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserContext _currentUserContext;

        public GetCurrentUserDetailsConsumer(
            IMapper mapper, 
            ICurrentUserContext currentUserContext)
        {
            _mapper = mapper;
            _currentUserContext = currentUserContext;
        }

        public async Task Consume(ConsumeContext<GetUserByIdRequest> context)
        {
            var userDetails = _currentUserContext.GetUserDetails();

            var getCurrentUserDetailsResponse = _mapper.Map<GetCurrentUserDetailsResponse>(userDetails);

            await context.RespondAsync(getCurrentUserDetailsResponse);
        }
    }
}
