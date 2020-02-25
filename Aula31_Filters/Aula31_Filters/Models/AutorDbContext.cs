using Microsoft.EntityFrameworkCore;

namespace Aula31_Filters.Models
{
    public class AutorDbContext:DbContext
    {
        public AutorDbContext(DbContextOptions<AutorDbContext>options)
            : base(options) { }

        public DbSet<Autor> Autores { get; set; }
    }
}
