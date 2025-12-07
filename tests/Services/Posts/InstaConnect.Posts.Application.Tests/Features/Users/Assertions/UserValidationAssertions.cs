namespace InstaConnect.Posts.Application.Tests.Features.Users.Assertions;

public static class UserValidationAssertions
{
    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<UpdateUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdateUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<DeleteUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        DeleteUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<AddUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForName(
        this TestValidationResult<UpdateUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdateUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Name, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForName(
        this TestValidationResult<AddUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Name, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForFirstName(
        this TestValidationResult<UpdateUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdateUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.FirstName, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForFirstName(
        this TestValidationResult<AddUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.FirstName, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForLastName(
        this TestValidationResult<UpdateUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdateUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.LastName, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForLastName(
        this TestValidationResult<AddUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.LastName, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForEmail(
        this TestValidationResult<UpdateUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdateUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Email, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForEmail(
        this TestValidationResult<AddUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Email, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForProfileImage(
        this TestValidationResult<UpdateUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdateUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.ProfileImageUrl, messageTransformer!, value);
    }

    public static void ShouldHaveValidationErrorForProfileImage(
        this TestValidationResult<AddUserCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.ProfileImageUrl, messageTransformer!, value);
    }

    public static void ShouldHaveValidationErrorForCreatedAtUtc(
        this TestValidationResult<AddUserCommandRequest> result,
        IDateTimeOffsetMessageTransformer messageTransformer,
        AddUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CreatedAtUtc, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForUpdatedAtUtc(
        this TestValidationResult<AddUserCommandRequest> result,
        IDateTimeOffsetMessageTransformer messageTransformer,
        AddUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UpdatedAtUtc, messageTransformer, value);
    }

    public static void ShouldHaveValidationErrorForUpdatedAtUtc(
        this TestValidationResult<UpdateUserCommandRequest> result,
        IDateTimeOffsetMessageTransformer messageTransformer,
        UpdateUserCommandRequest value)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UpdatedAtUtc, messageTransformer, value);
    }
}
