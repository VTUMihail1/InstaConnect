using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Write.Business.Commands.Posts.AddPost;

internal class AddPostCommandHandler : ICommandHandler<AddPostCommand, PostCommandViewModel>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostWriteRepository _postRepository;
    private readonly IRequestClient<GetUserByIdRequest> _getUserByIdRequestClient;

    public AddPostCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostWriteRepository postRepository,
        IRequestClient<GetUserByIdRequest> getUserByIdRequestClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _getUserByIdRequestClient = getUserByIdRequestClient;
    }

    public async Task<PostCommandViewModel> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var getUserByIdRequest = _mapper.Map<GetUserByIdRequest>(request);
        var getUserByIdResponse = await _getUserByIdRequestClient.GetResponse<GetUserByIdResponse>(getUserByIdRequest, cancellationToken);

        if (getUserByIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var post = _mapper.Map<Post>(request);
        _postRepository.Add(post);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentViewModel = _mapper.Map<PostCommandViewModel>(post);

        return postCommentViewModel;
    }
}
