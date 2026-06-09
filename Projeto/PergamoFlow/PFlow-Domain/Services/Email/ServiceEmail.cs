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
using System.Collections.Generic;
using MimeKit;
using MimeKit.Utils;
using MailKit.Net.Smtp;
using MailKit.Security;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;

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
                var mensagem = CriarMensagem(destinatario, assunto, conteudoTexto, caminhosAnexos);

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

        private MimeMessage CriarMensagem(string destinatario, string assunto, string conteudoTexto, List<string> caminhosAnexos)
        {
            var mensagem = new MimeMessage();
            mensagem.From.Add(new MailboxAddress("PFlow Sistema", _emailAutenticado));
            mensagem.To.Add(new MailboxAddress("", destinatario));
            mensagem.Subject = assunto;
                     
            var builder = new BodyBuilder();

            builder.TextBody = conteudoTexto;
            builder.HtmlBody = ProcessarTemplateHtml(builder, conteudoTexto);
                     
            AdicionarAnexos(builder, caminhosAnexos);
            mensagem.Body = builder.ToMessageBody();

            return mensagem;
        }
        private string ProcessarTemplateHtml(BodyBuilder builder, string conteudoTexto)
        {
            string caminhoTemplate = Path.Combine(AppContext.BaseDirectory, "Email", "template-padrao.html");
            string html = File.Exists(caminhoTemplate) ? File.ReadAllText(caminhoTemplate) : "<html><body>{CONTEUDO}</body></html>";

            // Inserir Logo Inline
            string caminhoLogo = Path.Combine(AppContext.BaseDirectory, "appicon.png");
            string tagImagem = "";
            if (File.Exists(caminhoLogo))
            {
                var imagem = builder.LinkedResources.Add(caminhoLogo);
                imagem.ContentId = MimeUtils.GenerateMessageId();
                tagImagem = $"<img src='cid:{imagem.ContentId}' alt='PFlow Logo' width='55' style='display: block; margin-left: auto; border-radius: 4px;' />";
            }

            return html.Replace("{CONTEUDO}", conteudoTexto.Replace("\n", "<br/>"))
                       .Replace("{IMAGEM_LOGO}", tagImagem);
        }

        private void AdicionarAnexos(BodyBuilder builder, List<string> caminhosAnexos)
        {
            if (caminhosAnexos == null) return;

            foreach (var caminho in caminhosAnexos)
            {
                if (!string.IsNullOrEmpty(caminho) && File.Exists(caminho))
                    builder.Attachments.Add(caminho);
                else
                    Console.WriteLine($"[AVISO] Arquivo ignorado: {caminho}");
            }
        }

        private async Task<bool> EnviarViaSmtpAsync(MimeMessage mensagem, UserCredential credential)
        {
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
    }
}