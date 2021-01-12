using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PDV.DataBase.Objetos;
using System.IO;

namespace PDV.Comum
{
    public class ContextoComum : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
                var connectionString = configuration.GetConnectionString("ConexaoMySQL");
                optionsBuilder.UseMySql(connectionString);
            }
        }
    }

    public class MySQLContextos : ContextoComum
    {
        public DbSet<Pessoas> Pessoa { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
    }
}