using Microsoft.EntityFrameworkCore;
using PDV.Comum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDV.DataBase.Objetos
{
    public class UsuarioContexto : ContextoComum
    {
        public DbSet<Usuario> Usuario { get; set; }
    }

    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_pessoa", TypeName = "int")]
        public decimal id_pessoa { get; set; }

        [Column("ds_login", TypeName = "varchar(20)")]
        public string ds_login { get; set; }
        
        [Column("ds_senha", TypeName = "varchar(50)")]
        public string ds_senha { get; set; }

        [Column("dt_bloqueio", TypeName = "date")]
        public DateTime dt_bloqueio { get; set; }

    }   
}
