using System;
using System.Threading.Tasks;
using PFlow_Domain.Services.Email;

namespace PFlow_Domain
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== INICIANDO TESTE PFLOW ===");

            bool sucesso = Task.Run(async () =>
            {
                var teste = new ServiceEmailTest();
                return await teste.ExecutarTeste();
            }).GetAwaiter().GetResult();

            Console.WriteLine(sucesso ? "Sucesso!" : "Falha.");            
        }
    }
}