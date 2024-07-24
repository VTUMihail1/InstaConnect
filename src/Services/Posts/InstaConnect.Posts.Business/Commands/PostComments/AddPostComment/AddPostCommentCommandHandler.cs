using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Write.Business.Commands.PostComments.AddPostComment;

internal class AddPostCommentCommandHandler : ICommandHandler<AddPostCommentCommand, PostCommentCommandViewModel>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostWriteRepository _postRepository;
    private readonly IPostCommentWriteRepository _postCommentRepository;
    private readonly IRequestClient<GetUserByIdRequest> _getUserByIdRequestClient;

    public AddPostCommentCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostWriteRepository postRepository,
        IPostCommentWriteRepository postCommentRepository,
        IRequestClient<GetUserByIdRequest> getUserByIdRequestClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _postCommentRepository = postCommentRepository;
        _getUserByIdRequestClient = getUserByIdRequestClient;
    }

    public async Task<PostCommentCommandViewModel> Handle(AddPostCommentCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var getUserByIdRequest = _mapper.Map<GetUserByIdRequest>(request);
        var getUserByIdResponse = await _getUserByIdRequestClient.GetResponse<GetUserByIdResponse>(getUserByIdRequest, cancellationToken);

        if (getUserByIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var postComment = _mapper.Map<PostComment>(request);
        _postCommentRepository.Add(postComment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentCommandViewModel = _mapper.Map<PostCommentCommandViewModel>(request);

        return postCommentCommandViewModel;
    }
}
