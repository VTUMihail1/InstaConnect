namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenTemplates
{
    public const string Added = """
                                <html>
                                    <body>
                                        <p>Please confirm your email address.</p>
                                        <p>{0}/{1}</p>
                                    </body>
                                </html>
                                """;
}
