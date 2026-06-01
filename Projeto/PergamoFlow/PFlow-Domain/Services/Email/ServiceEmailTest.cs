using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MimeKit;

namespace PFlow_Domain.Services.Email
{
    public class ServiceEmailTest
    {
        private readonly ServiceEmail _service;

        public ServiceEmailTest() => _service = new ServiceEmail();

        public async Task<bool> ExecutarTeste()
        {
            var mensagem = new MimeMessage();
            mensagem.From.Add(new MailboxAddress("", "deyran@gmail.com"));
            mensagem.To.Add(new MailboxAddress("", "deyran@gmail.com"));
            mensagem.Subject = "Teste de Integração PFlow";

            var builder = new BodyBuilder { TextBody = "Este é um disparo limpo via refatoração." };

            // Adição de anexo simplificada
            string arquivo = @"C:\PFlow\tmp\Bingo-Mesa.xlsx";
            if (File.Exists(arquivo)) builder.Attachments.Add(arquivo);

            mensagem.Body = builder.ToMessageBody();

            return await _service.EnviarAsync(mensagem);
        }
    }
}