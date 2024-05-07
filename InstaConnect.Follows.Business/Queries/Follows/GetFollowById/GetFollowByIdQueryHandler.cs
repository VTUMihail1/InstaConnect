using AutoMapper;
using InstaConnect.Follows.Business.Models;
using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Shared.Business.Exceptions.Follow;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Follows.Business.Queries.Follows.GetFollowById;

internal class GetFollowByIdQueryHandler : IQueryHandler<GetFollowByIdQuery, FollowViewDTO>
{
    private readonly IMapper _mapper;
    private readonly IFollowRepository _followRepository;

    public GetFollowByIdQueryHandler(
        IMapper mapper,
        IFollowRepository followRepository)
    {
        _mapper = mapper;
        _followRepository = followRepository;
    }

    public async Task<FollowViewDTO> Handle(GetFollowByIdQuery request, CancellationToken cancellationToken)
    {
        var follow = await _followRepository.GetByIdAsync(request.Id, cancellationToken);

        if (follow == null)
        {
            throw new FollowNotFoundException();
        }

        var followViewDTO = _mapper.Map<FollowViewDTO>(follow);

        return followViewDTO;
    }
}
