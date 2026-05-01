namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

public class GetAllUsersQueryRequestValidator : AbstractValidator<GetAllUsersQueryRequest>
{
	public GetAllUsersQueryRequestValidator()
	{
		RuleFor(c => c.Name)
			.UserNameMaxLengthWithMessage();

		RuleFor(c => c.FirstName)
			.UserFirstNameMaxLengthWithMessage();

		RuleFor(c => c.LastName)
			.UserLastNameMaxLengthWithMessage();

		RuleFor(c => c.CurrentId)
			.UserIdMaxLengthWithMessage();

		RuleFor(q => q.SortOrder)
			.NotEmptyWithMessage();

		RuleFor(q => q.SortTerm)
			.NotEmptyWithMessage();

		RuleFor(q => q.Page)
			.UserPageMinValueWithMessage()
			.UserPageMaxValueWithMessage();

		RuleFor(q => q.PageSize)
			.UserPageSizeMinValueWithMessage()
			.UserPageSizeMaxValueWithMessage();
	}
}
