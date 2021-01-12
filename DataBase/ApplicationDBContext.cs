using Microsoft.EntityFrameworkCore;

namespace PDV.DataBase
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
    }
}
