using System;
using System.Collections.Generic;
using System.Threading.Tasks; // Necessário para o Task.Run
using PFlow_Domain.Services.Email;

namespace PFlow_Domain
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== TESTE DE DISPARO DE E-MAIL PFLOW ===");

            try
            {
                // Criamos um contexto de execução para o nosso método assíncrono
                bool sucesso = Task.Run(async () =>
                {
                    var service = new ServiceEmail();

                    string destinatario = "deyran@gmail.com";
                    string assunto = "Teste de Integração PFlow";
                    string corpo = "Olá, este é um e-mail de teste enviado através do novo serviço centralizado do PFlow-Domain.";
                    var anexos = new List<string> { @"C:\PFlow\Services\tmp\MapaDeNotas.xlsx" };

                    Console.WriteLine($"Enviando e-mail para: {destinatario}...");

                    // Aqui dentro podemos usar o await normalmente
                    return await service.EnviarEmailAsync(destinatario, assunto, corpo, anexos);

                }).GetAwaiter().GetResult(); // Forçamos o Main a aguardar o resultado aqui

                if (sucesso)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n[SUCESSO] E-mail disparado com êxito!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[ERRO] O disparo falhou.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERRO FATAL] {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para sair...");
                Console.ReadKey();
            }
        }
    }
}