namespace InstaConnect.Common.Presentation.Tests.Utilities;

public static class FormMapper
{
    extension(string content)
    {
        public StringContent GetContent()
        {
            return new StringContent(content);
        }
    }


    extension(Stream content)
    {
        public StreamContent GetContent()
        {
            return new StreamContent(content);
        }
    }
}
