﻿using FluentValidation;

namespace InstaConnect.Posts.Business.Queries.Posts.GetPostById;

public class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdQuery>
{
    public GetPostByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
