using FluentValidation;
using InstaConnect.Messages.Business.Read.Queries.Messages.GetMessageById;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetMessageByIdQueryValidator : AbstractValidator<GetMessageByIdQuery>
{
    public GetMessageByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
