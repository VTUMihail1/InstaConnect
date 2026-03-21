using System.Net.Http.Headers;

using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserFormMapper
{
    extension(AddUserApiForm form)
    {
        public MultipartFormDataContent GetContent()
        {
            var multipartContent = new MultipartFormDataContent
            {
                { form.Name.GetContent(), nameof(form.Name) },
                { form.Email.GetContent(), nameof(form.Email) },
                { form.Password.GetContent(), nameof(form.Password) },
                { form.ConfirmPassword.GetContent(), nameof(form.ConfirmPassword) },
                { form.FirstName.GetContent(), nameof(form.FirstName) },
                { form.LastName.GetContent(), nameof(form.LastName) }
            };

            if (form.ProfileImage != null)
            {
                var streamContent = form.ProfileImage.OpenReadStream().GetContent();
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(form.ProfileImage.ContentType);
                multipartContent.Add(streamContent, nameof(form.ProfileImage), form.ProfileImage.FileName);
            }

            return multipartContent;

        }
    }

    extension(UpdateUserApiForm form)
    {
        public MultipartFormDataContent GetContent()
        {
            var multipartContent = new MultipartFormDataContent
            {
                { form.Name.GetContent(), nameof(form.Name) },
                { form.Email.GetContent(), nameof(form.Email) },
                { form.FirstName.GetContent(), nameof(form.FirstName) },
                { form.LastName.GetContent(), nameof(form.LastName) }
            };

            if (form.ProfileImage != null)
            {
                var streamContent = form.ProfileImage.OpenReadStream().GetContent();
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(form.ProfileImage.ContentType);
                multipartContent.Add(streamContent, nameof(form.ProfileImage), form.ProfileImage.FileName);
            }

            return multipartContent;

        }
    }
}
