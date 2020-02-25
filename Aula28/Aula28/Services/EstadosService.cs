using Aula28.Models;
using System.Collections.Generic;

namespace Aula28.Services
{
    public class EstadosService
    {
        public List<Estado> GetEstados()
        {
            return new List<Estado>() {
            new Estado("Sao paulo", "SP"),
            new Estado("Rio de janeiro", "RJ"),
            new Estado("Santa Catatina", "SC"),
            new Estado("Parana", "PR"),
            new Estado("Minas Gerais", "MG"),
        };
        }
    }
}
