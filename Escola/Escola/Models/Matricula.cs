using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escolas.Models
{public enum Nota
    {
        A,B,C,D,F
    }

    public class Matricula
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int EstudanteId { get; set; }
        public Nota? Nota { get; set; }
        public Curso Curso { get; set; }
        public Estudante Estudante { get; set; }

    }
}
