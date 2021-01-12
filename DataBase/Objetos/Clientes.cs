using Microsoft.EntityFrameworkCore;
using PDV.Comum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDV.DataBase.Objetos
{
    public class ClientesContext : ContextoComum
    {
        public DbSet<Clientes> Clientes { get; set; }
    }

    [Table("clientes")]
    public class Clientes
    {
        [Key]
        [Column("id_cliente", TypeName = "int")]
        public int? id_cliente { get; set; }

        [Required]
        [Column("id_pessoa", TypeName = "int")]
        public int? id_pessoa { get; set; }

        [Column("dt_nascimento", TypeName = "date")]
        public DateTime dt_nascimento { get; set; }

        [MaxLength(20)]
        [Column("rg_rne", TypeName = "varchar(20)")]
        public string rg_rne { get; set; }

        [MaxLength(20)]
        [Column("cpf_cnpj", TypeName = "varchar(20)")]
        public string cpf_cnpj { get; set; }                

        [ForeignKey("id_pessoa")]
        public Pessoas Pessoa { get; set; }
    }

    public class ClientesxPessoas : Pessoas
    {
        public int? id_cliente { get; set; }
        public DateTime dt_nascimento { get; set; }
        public string rg_rne { get; set; }
        public string cpf_cnpj { get; set; }
    }
}
