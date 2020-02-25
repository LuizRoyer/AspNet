using Microsoft.EntityFrameworkCore;

namespace Aula26.Data
{
    public class AvisoContext:DbContext
    {
        public AvisoContext(DbContextOptions<AvisoContext> options)
            : base(options) { }

        public DbSet<Aviso> Avisos { get; set; }
    }
}
