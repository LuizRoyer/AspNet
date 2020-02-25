using Microsoft.EntityFrameworkCore;

namespace MVC_CoreEF.Models
{
    public class AlunoContext :DbContext
    {
        public  AlunoContext(DbContextOptions<AlunoContext> options)
            : base(options)
        { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Socio> Socio { get; set; }
    }
}
