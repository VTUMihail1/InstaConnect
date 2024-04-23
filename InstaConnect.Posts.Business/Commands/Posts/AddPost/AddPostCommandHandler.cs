using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;
using MassTransit;
using MassTransit.RabbitMqTransport;
using MassTransit.RabbitMqTransport.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPost
{
    public class AddPostCommandHandler : ICommandHandler<AddPostCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IGetUserByIdRequestClient _requestClient;

        public AddPostCommandHandler(
            IMapper mapper,
            IPostRepository postRepository,
            IGetUserByIdRequestClient requestClient)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _requestClient = requestClient;
        }

        public async Task Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            var getUserByIdRequest = _mapper.Map<GetUserByIdRequest>(request);

            var getUserByIdResponse = await _requestClient.GetResponse<GetUserByIdResponse>(getUserByIdRequest, cancellationToken);

            if (!getUserByIdResponse.Message.Exists)
            {
                throw new UserNotFoundException();
            }

            var post = _mapper.Map<Post>(request);
            await _postRepository.AddAsync(post, cancellationToken);
        }
    }
}
