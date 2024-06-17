﻿using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Posts.Data.Models.Filters;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Queries.PostComments.GetAllFilteredPostComments;

internal class GetAllFilteredPostCommentsQueryHandler : IQueryHandler<GetAllFilteredPostCommentsQuery, ICollection<PostCommentViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IPostCommentRepository _postCommentRepository;

    public GetAllFilteredPostCommentsQueryHandler(
        IMapper mapper,
        IPostCommentRepository postCommentRepository)
    {
        _mapper = mapper;
        _postCommentRepository = postCommentRepository;
    }

    public async Task<ICollection<PostCommentViewModel>> Handle(GetAllFilteredPostCommentsQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<PostCommentFilteredCollectionQuery>(request);

        var postComments = await _postCommentRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<PostCommentViewModel>>(postComments);

        return response;
    }
}
