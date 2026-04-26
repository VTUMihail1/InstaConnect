namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenTemplates
{
    public const string Added = """
                                <html>
                                    <body>
                                        <p>Reset your password.</p>
                                        <p>{0}/{1}</p>
                                    </body>
                                </html>
                                """;
}
