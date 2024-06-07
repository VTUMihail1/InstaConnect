using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Users;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.Posts.AddPost;

internal class AddPostCommandHandler : ICommandHandler<AddPostCommand>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public AddPostCommandHandler(
        IMapper mapper,
        IPostRepository postRepository,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _postRepository = postRepository;
        _currentUserContext = currentUserContext;
    }

    public async Task Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();

        var post = _mapper.Map<Post>(request);
        _mapper.Map(currentUserDetails, post);
        await _postRepository.AddAsync(post, cancellationToken);
    }
}
