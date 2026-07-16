using System;

namespace PFlow_Domain.Administrativo.Entities
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public DateTime? DataNasc { get; set; }
        public string Naturalidade { get; set; }
        public int EstadoCivil { get; set; }
    }
}
