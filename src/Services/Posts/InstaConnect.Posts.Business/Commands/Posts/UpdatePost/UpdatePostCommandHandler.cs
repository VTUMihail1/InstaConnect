using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.Posts.UpdatePost;

public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public UpdatePostCommandHandler(
        IMapper mapper,
        IPostRepository postRepository,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _postRepository = postRepository;
        _currentUserContext = currentUserContext;
    }

    public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();

        if (currentUserDetails.Id != existingPost.UserId)
        {
            throw new AccountForbiddenException();
        }

        _mapper.Map(request, existingPost);
        await _postRepository.UpdateAsync(existingPost, cancellationToken);
    }
}
