using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPost
{
    public class AddPostCommentCommandHandler : ICommandHandler<AddPostCommentCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IGetUserByIdRequestClient _requestClient;

        public AddPostCommentCommandHandler(
            IMapper mapper,
            IPostRepository postRepository,
            IPostCommentRepository postCommentRepository,
            IGetUserByIdRequestClient requestClient)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _postCommentRepository = postCommentRepository;
            _requestClient = requestClient;
        }

        public async Task Handle(AddPostCommentCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId, cancellationToken);

            if(post == null)
            {
                throw new PostNotFoundException();
            }

            var getUserByIdRequest = _mapper.Map<GetUserByIdRequest>(request);
            var getUserByIdResponse = await _requestClient.GetResponse<GetUserByIdResponse>(getUserByIdRequest, cancellationToken);

            if (!getUserByIdResponse.Message.Exists)
            {
                throw new UserNotFoundException();
            }

            var existingPostComment = await _postCommentRepository.GetByIdAsync(request.PostCommentId, cancellationToken);

            if (request.PostCommentId != null && existingPostComment == null)
            {
                throw new PostCommentNotFoundException();
            }

            var postComment = _mapper.Map<PostComment>(request);
            await _postCommentRepository.AddAsync(postComment, cancellationToken);
        }
    }
}
