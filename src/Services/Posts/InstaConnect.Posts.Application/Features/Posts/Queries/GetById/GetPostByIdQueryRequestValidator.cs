namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

public class GetPostByIdQueryRequestValidator : AbstractValidator<GetPostByIdQueryRequest>
{
    public GetPostByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();
    }
}
