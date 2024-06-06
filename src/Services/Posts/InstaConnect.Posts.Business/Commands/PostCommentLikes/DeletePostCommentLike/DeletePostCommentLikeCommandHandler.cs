using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;

internal class DeletePostCommentLikeCommandHandler : ICommandHandler<DeletePostCommentLikeCommand>
{
    private readonly IMapper _mapper;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;
    private readonly IRequestClient<ValidateUserByIdRequest> _validateUserByIdRequestClient;

    public DeletePostCommentLikeCommandHandler(
        IMapper mapper,
        IPostCommentLikeRepository postCommentLikeRepository,
        IRequestClient<ValidateUserByIdRequest> validateUserByIdRequestClient)
    {
        _mapper = mapper;
        _postCommentLikeRepository = postCommentLikeRepository;
        _validateUserByIdRequestClient = validateUserByIdRequestClient;
    }

    public async Task Handle(DeletePostCommentLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPostCommentLike = await _postCommentLikeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostCommentLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        var validateUserByIdRequest = _mapper.Map<ValidateUserByIdRequest>(existingPostCommentLike);
        await _validateUserByIdRequestClient.GetResponse<ValidateUserByIdResponse>(validateUserByIdRequest, cancellationToken);

        await _postCommentLikeRepository.DeleteAsync(existingPostCommentLike, cancellationToken);
    }
}
