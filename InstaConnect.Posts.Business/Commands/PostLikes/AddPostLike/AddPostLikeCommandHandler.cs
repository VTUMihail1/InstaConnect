using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPost
{
    public class AddPostLikeCommandHandler : ICommandHandler<AddPostLikeCommand>
    {
        private const string POST_ALREADY_LIKED = "This user has already liked this post";

        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IGetUserByIdRequestClient _requestClient;
        private readonly IPostLikeRepository _postLikeRepository;

        public AddPostLikeCommandHandler(
            IMapper mapper,
            IPostRepository postRepository,
            IGetUserByIdRequestClient requestClient,
            IPostLikeRepository postLikeRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _requestClient = requestClient;
            _postLikeRepository = postLikeRepository;
        }

        public async Task Handle(AddPostLikeCommand request, CancellationToken cancellationToken)
        {
            var existingPost = _postRepository.GetByIdAsync(request.PostId, cancellationToken);

            if (existingPost == null)
            {
                throw new PostNotFoundException();
            }

            var getUserByIdRequest = _mapper.Map<GetUserByIdRequest>(request);
            var getUserByIdResponse = await _requestClient.GetResponse<GetUserByIdResponse>(getUserByIdRequest, cancellationToken);

            if (!getUserByIdResponse.Message.Exists)
            {
                throw new UserNotFoundException();
            }

            var existingPostLike = _postLikeRepository.GetByUserIdAndPostIdAsync(request.UserId, request.PostId, cancellationToken);

            if (existingPostLike == null)
            {
                throw new BadRequestException(POST_ALREADY_LIKED);
            }

            var postLike = _mapper.Map<PostLike>(request);
            await _postLikeRepository.AddAsync(postLike, cancellationToken);
        }
    }
}
