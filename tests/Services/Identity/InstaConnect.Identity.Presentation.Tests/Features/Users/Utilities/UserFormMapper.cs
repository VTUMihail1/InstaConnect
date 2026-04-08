using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserFormMapper
{
    extension(AddUserApiForm form)
    {
        public MultipartFormDataContent GetContent()
        {
            var multipartContent = new MultipartFormDataContent()
                .AddString(form.Name, nameof(form.Name))
                .AddString(form.Email, nameof(form.Email))
                .AddString(form.FirstName, nameof(form.FirstName))
                .AddString(form.LastName, nameof(form.LastName))
                .AddString(form.Password, nameof(form.Password))
                .AddString(form.ConfirmPassword, nameof(form.ConfirmPassword))
                .AddFile(form.ProfileImage, nameof(form.ProfileImage));

            return multipartContent;
        }
    }

    extension(UpdateUserApiForm form)
    {
        public MultipartFormDataContent GetContent()
        {
            var multipartContent = new MultipartFormDataContent()
                .AddString(form.Name, nameof(form.Name))
                .AddString(form.Email, nameof(form.Email))
                .AddString(form.FirstName, nameof(form.FirstName))
                .AddString(form.LastName, nameof(form.LastName))
                .AddFile(form.ProfileImage, nameof(form.ProfileImage));

            return multipartContent;

        }
    }
}
