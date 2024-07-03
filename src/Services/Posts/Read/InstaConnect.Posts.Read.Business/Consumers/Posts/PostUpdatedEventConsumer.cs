using AutoMapper;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Contracts.Posts;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Read.Business.Consumers.Posts;

internal class PostUpdatedEventConsumer : IConsumer<PostUpdatedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;

    public PostUpdatedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostRepository postRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
    }

    public async Task Consume(ConsumeContext<PostUpdatedEvent> context)
    {
        var existingPost = await _postRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingPost == null)
        {
            return;
        }

        _mapper.Map(context.Message, existingPost);
        _postRepository.Update(existingPost);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
