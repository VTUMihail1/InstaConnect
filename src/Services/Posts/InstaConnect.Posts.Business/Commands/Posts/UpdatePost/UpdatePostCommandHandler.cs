﻿using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Posts.Business.Commands.Posts.UpdatePost;

public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand, PostCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostWriteRepository _postWriteRepository;

    public UpdatePostCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IPostWriteRepository postWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _postWriteRepository = postWriteRepository;
    }

    public async Task<PostCommandViewModel> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        if (request.CurrentUserId != existingPost.UserId)
        {
            throw new AccountForbiddenException();
        }

        _instaConnectMapper.Map(request, existingPost);
        _postWriteRepository.Update(existingPost);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentViewModel = _instaConnectMapper.Map<PostCommandViewModel>(existingPost);

        return postCommentViewModel;
    }
}
