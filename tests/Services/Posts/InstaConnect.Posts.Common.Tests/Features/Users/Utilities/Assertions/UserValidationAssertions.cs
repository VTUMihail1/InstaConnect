using FluentValidation.TestHelper;

using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Users.Application.Features.Users.Commands.Add;
using InstaConnect.Users.Application.Features.Users.Commands.Delete;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Assertions;

public static class UserValidationAssertions
{
    public static void ShouldHaveValidationErrorForId(this TestValidationResult<UpdateUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<DeleteUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<AddUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForName(this TestValidationResult<UpdateUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Name, errorMessage);
    }

    public static void ShouldHaveValidationErrorForName(this TestValidationResult<AddUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Name, errorMessage);
    }

    public static void ShouldHaveValidationErrorForFirstName(this TestValidationResult<UpdateUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.FirstName, errorMessage);
    }

    public static void ShouldHaveValidationErrorForFirstName(this TestValidationResult<AddUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.FirstName, errorMessage);
    }

    public static void ShouldHaveValidationErrorForLastName(this TestValidationResult<UpdateUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.LastName, errorMessage);
    }

    public static void ShouldHaveValidationErrorForLastName(this TestValidationResult<AddUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.LastName, errorMessage);
    }

    public static void ShouldHaveValidationErrorForEmail(this TestValidationResult<UpdateUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Email, errorMessage);
    }

    public static void ShouldHaveValidationErrorForEmail(this TestValidationResult<AddUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Email, errorMessage);
    }

    public static void ShouldHaveValidationErrorForProfileImage(this TestValidationResult<UpdateUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.ProfileImage, errorMessage);
    }

    public static void ShouldHaveValidationErrorForProfileImage(this TestValidationResult<AddUserCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.ProfileImage, errorMessage);
    }
}
