using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;

namespace InstaConnect.Posts.Business.Commands.PostComments.UpdatePostComment;

internal class UpdatePostCommentCommandHandler : ICommandHandler<UpdatePostCommentCommand>
{
    private readonly IMapper _mapper;
    private readonly IPostCommentRepository _postCommentRepository;
    private readonly IValidateUserByIdRequestClient _requestClient;

    public UpdatePostCommentCommandHandler(
        IMapper mapper,
        IPostCommentRepository postCommentRepository,
        IValidateUserByIdRequestClient requestClient)
    {
        _mapper = mapper;
        _postCommentRepository = postCommentRepository;
        _requestClient = requestClient;
    }

    public async Task Handle(UpdatePostCommentCommand request, CancellationToken cancellationToken)
    {
        var existingPostComment = await _postCommentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var validateUserByIdRequest = _mapper.Map<ValidateUserByIdRequest>(request);
        await _requestClient.GetResponse<ValidateUserByIdResponse>(validateUserByIdRequest, cancellationToken);

        _mapper.Map(request, existingPostComment);
        await _postCommentRepository.UpdateAsync(existingPostComment, cancellationToken);
    }
}
