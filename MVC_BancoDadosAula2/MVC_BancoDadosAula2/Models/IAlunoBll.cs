using System.Collections.Generic;

namespace MVC_BancoDadosAula2.Models
{
    public  interface IAlunoBll
    {
        List<Aluno> GetAlunos();
        void IncluirAluno(Aluno aluno);
        void AtualizarAluno(Aluno aluno);
    }
}
