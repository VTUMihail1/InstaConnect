namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

public class GetAllUsersQueryRequestValidator : AbstractValidator<GetAllUsersQueryRequest>
{
    public GetAllUsersQueryRequestValidator()
    {
        RuleFor(c => c.Filter.Name.Value)
            .UserNameMaxLengthWithMessage();

        RuleFor(c => c.Filter.FirstName)
            .UserFirstNameMaxLengthWithMessage();

        RuleFor(c => c.Filter.LastName)
            .UserLastNameMaxLengthWithMessage();

        RuleFor(q => q.Sorting.Order)
            .NotEmptyWithMessage();

        RuleFor(q => q.Sorting.Property)
            .NotEmptyWithMessage();

        RuleFor(q => q.Pagination.Page)
            .NotEmptyWithMessage()
            .UserPageMinValueWithMessage()
            .UserPageMaxValueWithMessage();

        RuleFor(q => q.Pagination.PageSize)
            .NotEmptyWithMessage()
            .UserPageSizeMinValueWithMessage()
            .UserPageSizeMaxValueWithMessage();
    }
}
