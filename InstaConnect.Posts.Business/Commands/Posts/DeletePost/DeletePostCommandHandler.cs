using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.Posts.DeletePost;

internal class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    private readonly IRequestClient<ValidateUserByIdRequest> _validateUserByIdRequestClient;

    public DeletePostCommandHandler(
        IMapper mapper,
        IPostRepository postRepository,
        IRequestClient<ValidateUserByIdRequest> validateUserByIdRequestClient)
    {
        _mapper = mapper;
        _postRepository = postRepository;
        _validateUserByIdRequestClient = validateUserByIdRequestClient;
    }

    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var validateUserByIdRequest = _mapper.Map<ValidateUserByIdRequest>(existingPost);
        await _validateUserByIdRequestClient.GetResponse<ValidateUserByIdResponse>(validateUserByIdRequest, cancellationToken);

        await _postRepository.DeleteAsync(existingPost, cancellationToken);
    }
}
