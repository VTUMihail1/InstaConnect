namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

public class GetAllUsersQueryRequestValidator : AbstractValidator<GetAllUsersQueryRequest>
{
    public GetAllUsersQueryRequestValidator()
    {
        RuleFor(c => c.Filter.FirstName)
            .MaximumLength(UserConfigurations.FirstNameMaxLength)
            .WithMessage(q => UserErrorMessages.GetFirstNameTooLong(q.Filter.FirstName.Length));

        RuleFor(c => c.Filter.LastName)
            .MaximumLength(UserConfigurations.LastNameMaxLength)
            .WithMessage(q => UserErrorMessages.GetLastNameTooLong(q.Filter.LastName.Length));

        RuleFor(c => c.Filter.Name)
            .MaximumLength(UserConfigurations.NameMaxLength)
            .WithMessage(q => UserErrorMessages.GetNameTooLong(q.Filter.Name.Length));

        RuleFor(q => q.Sorting.Order)
            .NotEmpty()
            .WithMessage(CommonErrorMessages.GetSortOrderEmpty());

        RuleFor(q => q.Sorting.Property)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetSortPropertyEmpty());

        RuleFor(q => q.Pagination.Page)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetPageEmpty())
            .GreaterThanOrEqualTo(UserConfigurations.PageMinValue)
            .WithMessage(q => UserErrorMessages.GetPageTooSmall(q.Pagination.Page))
            .LessThanOrEqualTo(UserConfigurations.PageMaxValue)
            .WithMessage(q => UserErrorMessages.GetPageTooLarge(q.Pagination.Page));

        RuleFor(q => q.Pagination.PageSize)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetPageSizeEmpty())
            .GreaterThanOrEqualTo(UserConfigurations.PageSizeMinValue)
            .WithMessage(q => UserErrorMessages.GetPageSizeTooSmall(q.Pagination.PageSize))
            .LessThanOrEqualTo(UserConfigurations.PageSizeMaxValue)
            .WithMessage(q => UserErrorMessages.GetPageSizeTooLarge(q.Pagination.PageSize));
    }
}
