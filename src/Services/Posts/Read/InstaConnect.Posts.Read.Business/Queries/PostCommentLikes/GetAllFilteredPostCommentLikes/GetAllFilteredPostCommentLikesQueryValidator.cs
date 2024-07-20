﻿using FluentValidation;

namespace InstaConnect.Posts.Read.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;

public class GetAllFilteredPostCommentLikesQueryValidator : AbstractValidator<GetAllFilteredPostCommentLikesQuery>
{
    public GetAllFilteredPostCommentLikesQueryValidator()
    {
        RuleFor(q => q.Page)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.PageSize)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.SortOrder)
            .NotEmpty()
            .IsInEnum();

        RuleFor(q => q.SortPropertyName)
            .NotEmpty();
    }
}