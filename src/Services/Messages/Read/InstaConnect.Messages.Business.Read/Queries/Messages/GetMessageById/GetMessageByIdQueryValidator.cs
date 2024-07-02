using FluentValidation;

namespace InstaConnect.Messages.Business.Read.Queries.Messages.GetMessageById;

public class GetMessageByIdQueryValidator : AbstractValidator<GetMessageByIdQuery>
{
    public GetMessageByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
