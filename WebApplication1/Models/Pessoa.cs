using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Pessoa
    {
        public int ID { get; set; }

        [StringLength (60, MinimumLength = 3)]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Nascimento { get; set; }

        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "O CPF deve ter exatamente 11 números.")]
        [StringLength(11)]
        public String CPF { get; set; }

        [RegularExpression(@"^[0-9]{8}$",ErrorMessage = "O CEP deve ter exatamente 8 números.")]
        [StringLength(8)]
        public String CEP { get; set; }
    }

    public class PessoaDBContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}