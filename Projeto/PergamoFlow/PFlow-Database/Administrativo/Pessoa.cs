using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFlow_Database.Administrativo
{
    [Table("ADM_Pessoa")]
    public class Pessoa
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPessoa { get; set; }

        [Required]
        public string Nome { get; set; }

        public string RG { get; set; }

        [Index(IsUnique = true)]
        public string CPF { get; set; }

        public string Sexo { get; set; }

        public DateTime? DataNasc { get; set; }

        [MaxLength(2)]
        public string Naturalidade { get; set; }

        public int EstadoCivil { get; set; } // 0 a 4
    }
}