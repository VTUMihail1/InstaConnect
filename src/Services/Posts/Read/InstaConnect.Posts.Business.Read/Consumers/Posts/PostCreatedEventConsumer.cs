﻿using AutoMapper;
using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Posts.Data.Read.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Posts;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Read.Consumers.Posts;

internal class PostCreatedEventConsumer : IConsumer<PostCreatedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;

    public PostCreatedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostRepository postRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
    }

    public async Task Consume(ConsumeContext<PostCreatedEvent> context)
    {
        var post = _mapper.Map<Post>(context.Message);
        _postRepository.Add(post);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
