namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenTemplates
{
    public const string Added = """
        <!DOCTYPE html>
        <html lang="en">
        <head>
          <meta charset="UTF-8">
          <meta name="viewport" content="width=device-width,initial-scale=1.0">
          <title>Reset your password</title>
        </head>
        <body style="margin:0;padding:0;background-color:#f4f4f7;font-family:Arial,Helvetica,sans-serif;">
          <table width="100%" cellpadding="0" cellspacing="0" style="padding:48px 0;">
            <tr>
              <td align="center">
                <table width="100%" cellpadding="0" cellspacing="0" style="max-width:580px;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 8px rgba(0,0,0,0.06);">
                  <tr>
                    <td style="background:#4f46e5;padding:28px 40px;text-align:center;">
                      <h1 style="margin:0;color:#ffffff;font-size:22px;font-weight:700;letter-spacing:0.5px;">InstaConnect</h1>
                    </td>
                  </tr>
                  <tr>
                    <td style="padding:40px;">
                      <h2 style="margin:0 0 12px;color:#111827;font-size:20px;font-weight:600;">Reset your password</h2>
                      <p style="margin:0 0 28px;color:#6b7280;font-size:15px;line-height:1.7;">
                        We received a request to reset the password for your account.
                        Click the button below to choose a new password.
                        This link will expire in <strong style="color:#374151;">a few hours</strong>.
                      </p>
                      <table cellpadding="0" cellspacing="0">
                        <tr>
                          <td style="background:#4f46e5;border-radius:6px;text-align:center;">
                            <a href="{0}/{1}" style="display:inline-block;padding:14px 32px;color:#ffffff;font-size:15px;font-weight:600;text-decoration:none;letter-spacing:0.2px;">
                              Reset Password
                            </a>
                          </td>
                        </tr>
                      </table>
                      <p style="margin:28px 0 6px;color:#9ca3af;font-size:13px;">
                        If the button doesn't work, copy and paste this link into your browser:
                      </p>
                      <p style="margin:0 0 32px;font-size:13px;word-break:break-all;">
                        <a href="{0}/{1}" style="color:#4f46e5;text-decoration:none;">{0}/{1}</a>
                      </p>
                      <p style="margin:0;padding-top:24px;border-top:1px solid #f3f4f6;color:#9ca3af;font-size:13px;line-height:1.6;">
                        Didn't request a password reset? You can safely ignore this email &mdash; your password will not be changed.
                      </p>
                    </td>
                  </tr>
                  <tr>
                    <td style="padding:20px 40px;text-align:center;background:#f9fafb;border-top:1px solid #e5e7eb;">
                      <p style="margin:0;color:#9ca3af;font-size:12px;">&copy; InstaConnect. All rights reserved.</p>
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </body>
        </html>
        """;
}
