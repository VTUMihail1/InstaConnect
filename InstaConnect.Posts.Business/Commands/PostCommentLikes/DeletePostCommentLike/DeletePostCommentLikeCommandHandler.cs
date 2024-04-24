using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Repositories;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike
{
    public class DeletePostCommentLikeCommandHandler : ICommandHandler<DeletePostCommentLikeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IValidateUserByIdRequestClient _requestClient;
        private readonly IPostCommentLikeRepository _postCommentLikeRepository;

        public DeletePostCommentLikeCommandHandler(
            IMapper mapper,
            IValidateUserByIdRequestClient requestClient,
            IPostCommentLikeRepository postCommentLikeRepository)
        {
            _mapper = mapper;
            _requestClient = requestClient;
            _postCommentLikeRepository = postCommentLikeRepository;
        }

        public async Task Handle(DeletePostCommentLikeCommand request, CancellationToken cancellationToken)
        {
            var existingPostCommentLike = await _postCommentLikeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (existingPostCommentLike == null)
            {
                throw new PostLikeNotFoundException();
            }

            var validateUserByIdRequest = _mapper.Map<ValidateUserByIdRequest>(request);
            _mapper.Map(existingPostCommentLike, validateUserByIdRequest);

            var validateUserByIdResponse = await _requestClient.GetResponse<ValidateUserByIdResponse>(validateUserByIdRequest, cancellationToken);

            if (!validateUserByIdResponse.Message.IsValid)
            {
                throw new AccountForbiddenException();
            }

            await _postCommentLikeRepository.DeleteAsync(existingPostCommentLike, cancellationToken);
        }
    }
}
