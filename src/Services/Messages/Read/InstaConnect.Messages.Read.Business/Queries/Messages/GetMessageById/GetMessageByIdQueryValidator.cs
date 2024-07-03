using FluentValidation;

namespace InstaConnect.Messages.Read.Business.Queries.Messages.GetMessageById;

public class GetMessageByIdQueryValidator : AbstractValidator<GetMessageByIdQuery>
{
    public GetMessageByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
