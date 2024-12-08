namespace FinanceManagerBackend
{
    public class MailTemplates
    {
        public string htmlForgotPassword1 { get; set; } = @"
        <!DOCTYPE html>
        <html lang=""de"">
        <head>
            <meta charset=""UTF-8"">
            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
            <title>Passwort zurücksetzen</title>
            <style>
                body {font - family: Arial, sans-serif;
                    background-color: #f5f5f5;
                    margin: 0;
                    padding: 20px;
                }
                .container {background - color: #ffffff;
                    border-radius: 8px;
                    padding: 20px;
                    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
                    max-width: 600px;
                    margin: auto;
                }
                .header {font - size: 24px;
                    font-weight: bold;
                    color: #333333;
                    margin-bottom: 10px;
                }
                .message {font - size: 16px;
                    color: #555555;
                    margin-bottom: 20px;
                }
                .code {display: inline-block;
                    font-size: 22px;
                    font-weight: bold;
                    color: #d9534f;
                    background-color: #f9f9f9;
                    padding: 10px;
                    border-radius: 4px;
                    border: 1px dashed #d9534f;
                }
                .footer {margin - top: 20px;
                    font-size: 14px;
                    color: #777777;
                }
            </style>
        </head>
        <body>
            <div class=""container"">
                <div class=""header"">Passwort zurücksetzen</div>
                <div class=""message"">
                    Sie haben angefordert, Ihr Passwort zurückzusetzen. Verwenden Sie den untenstehenden 10-stelligen Code, um den Vorgang abzuschließen. Der Code ist 30 Minuten lang gültig.
                </div>
                <div class=""code"">";


        public string htmlForgotPassword2 { get; set; } = @"
            </p>
                </div>
                <div class=""footer"">
                    Wenn Sie diese Anforderung nicht gestellt haben, ignorieren Sie bitte diese E-Mail oder kontaktieren Sie den Support, falls Sie Bedenken haben.
                </div>
            </div>
        </body>
        </html>";
    }
}