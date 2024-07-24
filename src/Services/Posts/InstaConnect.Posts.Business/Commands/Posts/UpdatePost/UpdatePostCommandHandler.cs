using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Posts;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Write.Business.Commands.Posts.UpdatePost;

public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand, PostCommandViewModel>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostWriteRepository _postRepository;

    public UpdatePostCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostWriteRepository postRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
    }

    public async Task<PostCommandViewModel> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        if (request.CurrentUserId != existingPost.UserId)
        {
            throw new AccountForbiddenException();
        }

        _mapper.Map(request, existingPost);
        _postRepository.Update(existingPost);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentViewModel = _mapper.Map<PostCommandViewModel>(existingPost);

        return postCommentViewModel;
    }
}
