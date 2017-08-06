using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    //We'll use the Pessoa class to represent pessoas in a database. 
    //Each instance of a Movie object will correspond to a row within a database table, 
    //and each property of the Movie class will map to a column in the table.
    //Note: In order to use System.Data.Entity, and the related class, 
    //you need to install the Entity Framework NuGet Package. 
    //(Ferramentas->Gerenciador de pacotes NuGet->Console do Gerenciador de pacotes)

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

    //The PessoaDBContext class represents the Entity Framework pessoa database context, 
    //which handles fetching, storing, and updating Pessoa class instances in a database. 
    //The PessoaDBContext derives from the DbContext base class provided by the Entity Framework.

    //Banco de dados: Especificado como um arquivo .mdf na pasta App_Data.
    //O Entity Framework procura automaticamente por uma connection string com 
    //o mesmo nome da classe de contexto de objeto PessoaDBContext.
    //Mas como especificar pra qual banco de dados a classe PessoaDBContext irá se conectar?
    //O Entity Framework vai automaticamente usar o LocalDB. 
    //Abra o root/Web.config pra mais detalhes
}