using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;

namespace InstaConnect.Posts.Business.Commands.PostComments.DeletePost
{
    public class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IValidateUserByIdRequestClient _requestClient;

        public DeletePostCommandHandler(
            IMapper mapper,
            IPostRepository postRepository,
            IValidateUserByIdRequestClient requestClient)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _requestClient = requestClient;
        }

        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var existingPost = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

            if (existingPost == null)
            {
                throw new PostNotFoundException();
            }

            var validateUserByIdRequest = _mapper.Map<ValidateUserByIdRequest>(request);
            _mapper.Map(existingPost, validateUserByIdRequest);

            var validateUserByIdResponse = await _requestClient.GetResponse<ValidateUserByIdResponse>(validateUserByIdRequest, cancellationToken);

            if (!validateUserByIdResponse.Message.IsValid)
            {
                throw new AccountForbiddenException();
            }

            await _postRepository.DeleteAsync(existingPost, cancellationToken);
        }
    }
}
