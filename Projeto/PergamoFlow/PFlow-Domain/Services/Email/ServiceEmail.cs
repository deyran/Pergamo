using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PFlow_Domain.Services.Email
{
    public class ServiceEmail
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _emailAutenticado;
        private readonly string[] _scopes = new[] { "https://mail.google.com/" };

        public ServiceEmail()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false).Build();

            _clientId = config["GoogleOAuth:ClientId"];
            _clientSecret = config["GoogleOAuth:ClientSecret"];
            _emailAutenticado = config["GoogleOAuth:EmailAutenticado"];
        }

        public async Task<bool> EnviarAsync(MimeMessage mensagem)
        {
            try
            {
                var credential = await ObterCredenciaisAsync();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    var oauth2 = new SaslMechanismOAuth2(_emailAutenticado, credential.Token.AccessToken);
                    await client.AuthenticateAsync(oauth2);
                    await client.SendAsync(mensagem);
                    await client.DisconnectAsync(true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERRO SMTP] {ex.Message}");
                return false;
            }
        }

        private async Task<UserCredential> ObterCredenciaisAsync()
        {
            string caminhoToken = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PFlowTokens");
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets { ClientId = _clientId, ClientSecret = _clientSecret },
                _scopes, _emailAutenticado, CancellationToken.None, new FileDataStore(caminhoToken, true)
            );
            await credential.RefreshTokenAsync(CancellationToken.None);
            return credential;
        }
    }
}