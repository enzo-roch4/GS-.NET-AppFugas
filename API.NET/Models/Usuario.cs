using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.NET.Models
{
    public class Usuario
    {
        [Key]
        [Column("ID")]
        public int id { get; set; }

        [Column("NOME")]
        public string nome { get; set; }

        [Column("CPF")]
        public string cpf { get; set; }

        [Column("EMAIL")]
        public string email { get; set; }

        [Column("SENHA")]
        public string senha { get; set; }
    }
}
