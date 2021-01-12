using Microsoft.EntityFrameworkCore;
using PDV.Comum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDV.DataBase.Objetos
{
    public class PessoaContexto : ContextoComum
    {
        public DbSet<Pessoas> Pessoa { get; set; }
    }

    [Table("pessoas")]
    public class Pessoas
    {
        [Key]
        [Column("id_pessoa", TypeName = "int")]
        public int? id_pessoa { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        [Column("nm_pessoa", TypeName = "varchar(100)")]
        public string nm_pessoa { get; set; }

        [Required]
        [MaxLength(1)]
        [Column("tp_pessoa", TypeName = "char(1)")]
        public string tp_pessoa { get; set; }

        [Required]
        [Column("dt_cadastro", TypeName = "datetime")]
        public DateTime dt_cadastro { get; set; }

        [Required]
        [Column("dt_alterado", TypeName = "datetime")]
        public DateTime dt_alterado { get; set; }

        [MaxLength(8)]
        [Column("nr_cep", TypeName = "int")]
        public int nr_cep { get; set; }

        [MaxLength(30)]
        [Column("ds_complemento", TypeName = "varchar(30)")]
        public string ds_complemento { get; set; }

        [MaxLength(50)]
        [Column("obsr", TypeName = "varchar(50)")]
        public string obsr { get; set; }
    }
}
